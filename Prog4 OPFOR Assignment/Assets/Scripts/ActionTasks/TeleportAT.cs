using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class TeleportAT : ActionTask {

		public BBParameter<Transform> activeWaypoint;
		public LayerMask waypointMask;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			Collider[] availableWaypoints = Physics.OverlapSphere(agent.transform.position, 100, waypointMask);

			int randomNumInArray = Random.Range(0, availableWaypoints.Length);

			agent.transform.position = availableWaypoints[randomNumInArray].transform.position;
			agent.transform.forward = availableWaypoints[randomNumInArray].transform.forward;
			activeWaypoint.value = availableWaypoints[randomNumInArray].transform;

			EndAction(true);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}