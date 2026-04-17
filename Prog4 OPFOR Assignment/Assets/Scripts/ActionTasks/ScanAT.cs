using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {

		private Vector3 startAngle;
		private bool turningRight = true;
        public BBParameter<float> scanAngleBBP;
		public BBParameter<Transform> activeWaypointBBP;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			startAngle = activeWaypointBBP.value.transform.forward.normalized;

			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            //Debug.Log("Angle Relative to Waypoint" + Vector3.Angle(startAngle, agent.transform.forward));

            if (turningRight)
			{

				agent.transform.Rotate(Vector3.up * Time.deltaTime * 5);				

				if(Vector3.Angle(startAngle, agent.transform.forward) > scanAngleBBP.value)
				{

					turningRight = false;

				}

			}
			else
			{

                agent.transform.Rotate(-Vector3.up * Time.deltaTime * 5);

                if (Vector3.Angle(startAngle, agent.transform.forward) > scanAngleBBP.value)
                {

                    turningRight = true;
					EndAction(true);

                }

            }
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}