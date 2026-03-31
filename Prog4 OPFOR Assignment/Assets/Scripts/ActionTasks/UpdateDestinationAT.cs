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

            if (NavMesh.SamplePosition(targetPosMarker.value.transform.position, out NavMeshHit hitInfo, 10, NavMesh.AllAreas))
            {

                targetPosMarker.value.transform.position = hitInfo.position;

            }

            EndAction(true);
		}

	}
}