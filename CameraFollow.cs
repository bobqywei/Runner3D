using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	public GameObject Player, Menu, tower;
	public static int mode;
	public static bool transition, initialize;
	Vector3 correctPos;
	Vector3 correctAngle;

	Quaternion startRot, correctRot;
	Vector3 startPos, startAngle;

	Vector3 startPlayerPos, endPlayerPos;

	Vector3 menuPos;
	Vector3 decrement = new Vector3 (0.5F, 0, 0);
	float percent;

	void Start ()
	{
		startAngle = transform.eulerAngles;
		startPos = transform.position;
	}
	
	void Update ()
	{
		//checks if game mode is in 1 and if gameplay is running
		if (Variables.playing && Variables.gameMode == 1) {
			//establishes the 'correct' position by lerping between the 
			//camera's current position and the player object's current
			//position at double the game speed
			correctPos = Vector3.Lerp (gameObject.transform.position - decrement
			                           , Player.transform.position
			                           , Variables.speed * 2);
			menuPos = Vector3.Lerp (Menu.transform.position, Player.transform.position, Variables.speed * 2);
			//sets the camera's horizontal coordinate to that of the 'correct' position
			gameObject.transform.position = new Vector3 (correctPos.x + 0.5F, transform.position.y, transform.position.z);
			Menu.transform.position = new Vector3 (menuPos.x, 0, 0);

			if (mode == 2) {
				if (transition) {
					if (initialize) {
						startPlayerPos = Player.transform.position;
						endPlayerPos = new Vector3 (Variables.pathArray [0].transform.position.x, Player.transform.position.y, Player.transform.position.z);

						startPos = transform.position;
						startRot = transform.rotation;
						initialize = false;
					}

					correctPos = new Vector3 (Player.transform.position.x + 0.5f, 6, -9);
					correctRot = Quaternion.Euler (new Vector3 (45, 355, 0));
					percent += Variables.speed / 2;

					Player.transform.position = Vector3.Lerp (startPlayerPos, endPlayerPos, percent);
					transform.position = Vector3.Lerp (startPos, correctPos, percent);
					transform.rotation = Quaternion.Lerp (startRot, correctRot, percent);

					if (percent >= 0.9) {
						GameMode.ignoreSequence = false;
						Player.transform.position = endPlayerPos;
						transform.position = correctPos;
						transform.rotation = correctRot;

						transition = false;
						Variables.rawSpeed = SpeedController.currentSpeed;
						percent = 0;
					}
				}
			} else if (mode == 3) {
				if (transition) {
					if (initialize) {
						startPlayerPos = Player.transform.position;
						endPlayerPos = new Vector3 (Player.transform.position.x, 0, Player.transform.position.z);

						startPos = transform.position;
						startRot = transform.rotation;
						initialize = false;
					}

					correctPos = new Vector3 (Player.transform.position.x + 0.5f, 6, -9); 
					correctRot = Quaternion.Euler (new Vector3 (45, 355, 0));
					percent += Variables.speed / 2;

					Player.transform.position = Vector3.Lerp (startPlayerPos, endPlayerPos, percent);
					transform.position = Vector3.Lerp (startPos, correctPos, percent);
					transform.rotation = Quaternion.Lerp (startRot, correctRot, percent);

					if (percent >= 0.9) {
						transform.position = correctPos;
						transform.rotation = correctRot;
						Player.transform.position = endPlayerPos;

						Destroy (GameMode.jetpack,0);
						Destroy (GameMode.jeteffect1,0);
						Destroy (GameMode.jeteffect2,0);
						
						transition = false;
						Variables.rawSpeed = SpeedController.currentSpeed;
						percent = 0;
					}
				}
			}

		} else if (Variables.playing && Variables.gameMode == 2) {

			if (transition) {
				if (initialize) {
					startPos = transform.position;
					startAngle = transform.eulerAngles;
					initialize = false;
				}

				correctPos = new Vector3 (Player.transform.position.x, 9, -6);
				correctAngle = new Vector3 (75, 360, 0);
				percent += Variables.speed / 2;

				transform.position = Vector3.Lerp (startPos, correctPos, percent);
				transform.eulerAngles = Vector3.Lerp (startAngle, correctAngle, percent);

				if (percent >= 0.9) {
					transform.position = correctPos;
					transform.eulerAngles = correctAngle;

					transition = false;
					Variables.rawSpeed = SpeedController.currentSpeed;
					percent = 0;
				}
			} else {
				correctPos = Vector3.Lerp (gameObject.transform.position, Player.transform.position, Variables.speed * 2);
				gameObject.transform.position = new Vector3 (correctPos.x, transform.position.y, transform.position.z);
			}

		} else if (Variables.playing && Variables.gameMode == 3) {
			if (transition) {
				if (initialize) {
					startPos = transform.position;
					startAngle = transform.eulerAngles;
					initialize = false;
				}

				correctPos = new Vector3 (Player.transform.position.x + 4, 0, -9);
				correctAngle = new Vector3 (0, 328, 0);
				percent += Variables.speed / 2;
				
				transform.position = Vector3.Lerp (startPos, correctPos, percent);
				transform.eulerAngles = Vector3.Lerp (startAngle, correctAngle, percent);
				
				if (percent >= 0.9) {
					transform.position = correctPos;
					transform.eulerAngles = correctAngle;
					
					transition = false;
					Variables.rawSpeed = SpeedController.currentSpeed;
					percent = 0;

					Variables.towerArrayLower.Add (Instantiate (tower) as GameObject); 
					Variables.towerArrayUpper.Add (Instantiate (tower) as GameObject);
					Variables.towerArrayLower [Variables.towerArrayLower.Count - 1].transform.position = new Vector3 (Player.transform.position.x, -9.5f, 20);
					Variables.towerArrayUpper [Variables.towerArrayUpper.Count - 1].transform.position = new Vector3 (Player.transform.position.x, 9.5f, 20);
					Variables.towerBool.Add (false);
				}
			}
		}
	}
}
