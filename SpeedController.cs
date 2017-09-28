using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour {
	float startTime;
	public static float currentSpeed;

	void Update () {
		if (Variables.playing) {
			if (!Variables.jetPack) {
				if (Time.time - startTime >= 5) {
					startTime = Time.time;
					if (Variables.rawSpeed < 10) {
						Variables.rawSpeed += 0.1F;
					}
				}
				Variables.speed = Variables.rawSpeed * Time.smoothDeltaTime;
			}
			else {
				Variables.speed = Variables.rawSpeed * Time.smoothDeltaTime;
				startTime = Time.time;
			}

		} else {
			if (Input.GetButtonDown ("down") || Input.touchCount > 1){
					startTime = Time.time;
			}
		}
	}
}
