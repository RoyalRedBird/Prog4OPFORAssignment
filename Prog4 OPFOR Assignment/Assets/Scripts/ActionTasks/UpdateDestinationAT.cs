using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class UpdateDestinationAT : ActionTask {

		public BBParameter<GameObject> targetPosMarker;
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
        protected override void OnExecute() {

            Vector3 randomPoint = Vector3.zero + Random.insideUnitSphere * 125;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hitInfo, 50, NavMesh.AllAreas))
            {

                Debug.Log("Destionation Updated To: " + hitInfo.position);
                targetPosMarker.value.transform.position = hitInfo.position;

            }

            EndAction(true);
		}

	}
}