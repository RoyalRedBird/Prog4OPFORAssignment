using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class FlyToPosAT : ActionTask {


        public BBParameter<float> moveSpeed;
        public BBParameter<float> flySpeed;
        public BBParameter<GameObject> destinationMarker;
        public BBParameter<bool> isAscending = false;

        private NavMeshAgent navAgent;

        protected override string OnInit()
        {

            navAgent = agent.GetComponent<NavMeshAgent>();

            if (navAgent == null)
                return $"{agent.name} - NavigationTask: NavMesh not found in agent!.";
            else
                return null;

        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnUpdate() {

            Vector3 currentSpeed = new Vector3();

            RaycastHit forwardHit;
            Debug.DrawLine(agent.transform.position, agent.transform.forward * 5 + agent.transform.position);
            if (Physics.Raycast(agent.transform.position, agent.transform.forward, out forwardHit, 5f))
            {

                currentSpeed.y += flySpeed.value * Time.deltaTime;
                currentSpeed.x += moveSpeed.value * Time.deltaTime;
                isAscending = true;

            }
            else
            {

                currentSpeed.x = moveSpeed.value * Time.deltaTime ;
                isAscending = false;

            }

            if (!isAscending.value)
            {

                if (!Physics.Raycast(agent.transform.position, -agent.transform.up, out RaycastHit downHit, 1.5f))
                {

                    currentSpeed.y += -flySpeed.value * Time.deltaTime;

                }
            }

            agent.transform.position += currentSpeed;

            if(Vector3.Distance(agent.transform.position, destinationMarker.value.transform.position) < 1)
            {

                EndAction(true);

            }
            
		}

	}

}