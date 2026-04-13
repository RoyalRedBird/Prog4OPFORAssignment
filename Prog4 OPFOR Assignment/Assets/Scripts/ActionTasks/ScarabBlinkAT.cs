using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ScarabBlinkAT : ActionTask {

		public BBParameter<float> BlinkTimerBBP;
		public BBParameter<float> baseLightIntensityBBP;
        public BBParameter<Light> ScarabLightBBP;

		private float blinkTimer;
		private float lightIntensity;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			blinkTimer = BlinkTimerBBP.value;
			ScarabLightBBP.value.intensity = baseLightIntensityBBP.value;

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			blinkTimer -= Time.deltaTime;
			ScarabLightBBP.value.intensity -= Time.deltaTime * 20;


			if(blinkTimer < 0) { 
			
				EndAction(true);
			
			}

        }

	}

}