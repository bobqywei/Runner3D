using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject Player, Menu;
	public static bool transition, initialize;
	Vector3 correctPos;
	Vector3 correctAngle;
	Quaternion startRot, correctRot;
	
	Vector3 startPos, startAngle;

	Vector3 menuPos;
	Vector3 decrement = new Vector3(0.5F,0,0);

	float percent;

	void Start () {
		startAngle = transform.eulerAngles;
		startPos = transform.position;
	}
	
	void Update () {
		if (Variables.playing && Variables.gameMode == 1) {
			correctPos = Vector3.Lerp (gameObject.transform.position - decrement, Player.transform.position, Variables.speed * 2);
			menuPos = Vector3.Lerp (Menu.transform.position, Player.transform.position, Variables.speed * 2);

			gameObject.transform.position = new Vector3 (correctPos.x + 0.5F, transform.position.y, transform.position.z);
			Menu.transform.position = new Vector3 (menuPos.x, 0, 0);

			if (transition) {
				if (initialize) {
					startPos = transform.position;
					startRot = transform.rotation;
					initialize = false;
				}

				correctPos = new Vector3 (Player.transform.position.x + 0.5f, 6, -9);
				correctRot = Quaternion.Euler(new Vector3(45, 355, 0));
				percent += Variables.speed/2;

				transform.position = Vector3.Lerp (startPos, correctPos, percent);
				transform.rotation = Quaternion.Lerp (startRot, correctRot, percent);

				if (percent >= 0.9) {
					transform.position = correctPos;
					transform.rotation = correctRot;

					transition = false;
					Variables.rawSpeed = SpeedController.currentSpeed;
					percent = 0;
				}
			}

		} else if (Variables.playing && Variables.gameMode == 2) {

			if (transition) {
				if (initialize) {
					startPos = transform.position;
					startAngle = transform.eulerAngles;
					initialize = false;
				}

				correctPos = new Vector3(Player.transform.position.x, 9, -6);
				correctAngle = new Vector3(75, 360, 0);
				percent += Variables.speed/2;

				transform.position = Vector3.Lerp (startPos, correctPos, percent);
				transform.eulerAngles = Vector3.Lerp (startAngle, correctAngle, percent);

				if (percent >= 0.9) {
					transform.position = correctPos;
					transform.eulerAngles = correctAngle;

					transition = false;
					Variables.rawSpeed = SpeedController.currentSpeed;
					percent = 0;
				}
			}
			else {
				correctPos = Vector3.Lerp (gameObject.transform.position, Player.transform.position, Variables.speed * 2);
				gameObject.transform.position = new Vector3 (correctPos.x, transform.position.y, transform.position.z);
			}
		}
	}
}
