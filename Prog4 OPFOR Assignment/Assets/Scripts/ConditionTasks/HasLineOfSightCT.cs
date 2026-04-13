using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class HasLineOfSightCT : ConditionTask {

		public BBParameter<Transform> playerTransform;
		public LayerMask playerMask;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			Vector3 directionToPlayer = playerTransform.value.position - agent.transform.position;
			directionToPlayer = directionToPlayer.normalized;
			
			if(Physics.Raycast(agent.transform.position, directionToPlayer, out RaycastHit rayHit, 100f)){}

            Debug.DrawLine(agent.transform.position, rayHit.point, Color.gold);

			if(rayHit.collider != null)
			{

                if(rayHit.collider.gameObject.name == "PlayerCapsule")
                {

					Debug.Log("Player in line of sight!");
                    return true;

                }
                else
                {

                    return false;

                }

			}
			else
			{

				return false;

			}          

        }

	}

}