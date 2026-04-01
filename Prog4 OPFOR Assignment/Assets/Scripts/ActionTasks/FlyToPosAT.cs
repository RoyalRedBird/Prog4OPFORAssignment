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
        private Rigidbody scarabRB;

        protected override string OnInit()
        {

            scarabRB = agent.GetComponent<Rigidbody>();

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

            Vector3 currentSpeed = agent.transform.position;

            RaycastHit forwardHit;
            Debug.DrawLine(agent.transform.position, agent.transform.forward * 5 + agent.transform.position);
            if (Physics.Raycast(agent.transform.position, agent.transform.forward, out forwardHit, 5f))
            {

                Debug.Log("There is something in front of me!");

                if(forwardHit.rigidbody != null)
                {

                    scarabRB.linearVelocity = agent.transform.forward * moveSpeed.value;
                    //currentSpeed += agent.transform.forward + currentSpeed * Time.deltaTime;
                    //currentSpeed.y += flySpeed.value * Time.deltaTime;
                    scarabRB.AddForce(new Vector3(0, flySpeed.value * Time.deltaTime), ForceMode.Force);
                    isAscending = true;

                }

            }
            else
            {

                scarabRB.linearVelocity = agent.transform.forward * moveSpeed.value;
                //currentSpeed = agent.transform.forward + currentSpeed * Time.deltaTime;
                isAscending = false;

            }

            if (!isAscending.value)
            {

                if (!Physics.Raycast(agent.transform.position, -agent.transform.up, out RaycastHit downHit, 1.5f))
                {

                    currentSpeed.y += -flySpeed.value * Time.deltaTime;

                }
            }

            //agent.transform.position = currentSpeed;

            if(Vector3.Distance(agent.transform.position, destinationMarker.value.transform.position) < 1)
            {

                EndAction(true);

            }
            
		}

	}

}