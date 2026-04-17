using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AlertDeathmarkAT : ActionTask {

		private Blackboard DeathmarkBlackboard;
		public BBParameter<GameObject> deathmarkBBP;
        public BBParameter<GameObject> playerBBP;
        public LayerMask waypointMask;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			DeathmarkBlackboard = deathmarkBBP.value.GetComponent<Blackboard>();

			if(deathmarkBBP == null )
			{

				Debug.Log("Scarab could not grab deathmark blackboard.");

			}

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			Collider[] nearbyWaypoints = Physics.OverlapSphere(agent.transform.position, 50f, waypointMask);

			float nearestDistance = 9999f;
			Collider nearestWaypoint = null;

			foreach(Collider collider in nearbyWaypoints)
			{

				if(Vector3.Distance(playerBBP.value.transform.position, collider.transform.position) < nearestDistance)
				{

					nearestWaypoint = collider;
					nearestDistance = Vector3.Distance(playerBBP.value.transform.position, collider.transform.position);


                }

			}

            deathmarkBBP.value.transform.position = nearestWaypoint.transform.position;
            agent.transform.forward = nearestWaypoint.transform.forward;
			DeathmarkBlackboard.SetVariableValue("activeWaypoint", nearestWaypoint);
            DeathmarkBlackboard.SetVariableValue("onAlert", true);
            DeathmarkBlackboard.SetVariableValue("alertness", 150);

            EndAction(true);

		}

	}

}