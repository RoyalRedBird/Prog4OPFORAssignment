using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class StopScarabAT : ActionTask {

        private Rigidbody scarabRB;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            scarabRB = agent.GetComponent<Rigidbody>();

            if (scarabRB == null)
                return $"{agent.name} - NavigationTask: Rigidbody not found in agent!.";
            else
                return null;
        }

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            scarabRB.angularVelocity = Vector3.zero;
            scarabRB.linearVelocity = Vector3.zero;
            agent.transform.position = agent.transform.position;
            EndAction(true);

		}

	}
}