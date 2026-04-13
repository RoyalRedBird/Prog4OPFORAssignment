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
        public LayerMask wallMask;

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
            Vector3 scarabVelocity = agent.transform.forward * moveSpeed.value * Time.deltaTime;

            //scarabRB.linearVelocity = agent.transform.forward * moveSpeed.value * Time.deltaTime;
            Vector3 wallLineStartPos = agent.transform.position;
            wallLineStartPos.y = agent.transform.position.y - 1.5f;

            RaycastHit forwardHit;
            Debug.DrawLine(wallLineStartPos, agent.transform.forward * 5 + agent.transform.position);
            if (Physics.Raycast(wallLineStartPos, agent.transform.forward, out forwardHit, 5f, wallMask))
            {             

                if(forwardHit.collider != null)
                {

                    Debug.Log("There is something in front of me!");
                    //currentSpeed += agent.transform.forward + currentSpeed * Time.deltaTime;
                    //currentSpeed.y += flySpeed.value * Time.deltaTime;
                    //scarabRB.AddForce(new Vector3(0, flySpeed.value * Time.deltaTime), ForceMode.Acceleration);
                    scarabVelocity.y = flySpeed.value * Time.deltaTime;
                    isAscending = true;

                }

            }
            else
            {

                //currentSpeed = agent.transform.forward + currentSpeed * Time.deltaTime;
                isAscending = false;

            }

            if (!isAscending.value)
            {

                if (!Physics.Raycast(agent.transform.position, -agent.transform.up, out RaycastHit downHit, 1.5f))
                {

                    currentSpeed.y += -flySpeed.value * Time.deltaTime;
                    scarabVelocity.y = -(flySpeed.value * Time.deltaTime);

                }
            }

            //agent.transform.position = currentSpeed;
            //Debug.Log("Scarab Velocity: " + scarabVelocity);
            scarabRB.linearVelocity = scarabVelocity;

            Vector3 scarabPosFlat = agent.transform.position;
            scarabPosFlat.y = 0;

            Vector3 destinationPosFlat = destinationMarker.value.transform.position;
            destinationPosFlat.y = 0;

            if(Vector3.Distance(scarabPosFlat, destinationPosFlat) < 1)
            {

                scarabRB.linearVelocity = Vector3.zero;
                EndAction(true);

            }
            
		}

	}

}