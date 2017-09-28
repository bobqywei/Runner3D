using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public static bool end, transition, up, safe;
	Vector3 endpos, startpos, track;
	float perc;
	float distance;

	void Update () {
		if (Variables.playing && Variables.jetPack) {
			if (!end) {
				if (up) {
					startpos = new Vector3 (gameObject.transform.position.x, 0, gameObject.transform.position.z);
					endpos = new Vector3 (gameObject.transform.position.x, 2, gameObject.transform.position.z);
					perc += Variables.speed / 5;
					gameObject.transform.position = Vector3.Lerp (startpos, endpos, perc);

					if (perc > 1) {
						gameObject.transform.position = endpos;
						up = false;
						Variables.rawSpeed = 12;
						perc = 0;
					}
				} else {
					distance += Variables.speed;

					if (distance > 100) {
						end = true;
						Variables.rawSpeed = 1;
						distance = 0;
						track = gameObject.transform.position;
					}
				}
			} else {
				if (!transition) {
					distance += Variables.speed;
					CollectObject.jetPack.GetComponentInChildren<MeshRenderer> ().enabled = !CollectObject.jetPack.GetComponentInChildren<MeshRenderer> ().enabled;

					if (distance > 2.5) {
						if(gameObject.transform.position != track) {
							gameObject.transform.position = PlayerJump.endpos;
						}
						transition = true;
						distance = 0;
						startpos = gameObject.transform.position;
						endpos = new Vector3 (gameObject.transform.position.x, 0, gameObject.transform.position.z);
						gameObject.transform.position = new Vector3 (PlayerJump.endpos.x, gameObject.transform.position.y, gameObject.transform.position.z); 
						Destroy (CollectObject.jetEffect1, 0);
						Destroy (CollectObject.jetEffect2, 0);
					}
				} else {
					perc += Variables.speed / 2;
					gameObject.transform.position = Vector3.Lerp (startpos, endpos, perc);
					CollectObject.jetPack.GetComponentInChildren<MeshRenderer> ().enabled = !CollectObject.jetPack.GetComponentInChildren<MeshRenderer> ().enabled;
					gameObject.GetComponentInChildren<MeshRenderer> ().enabled = !gameObject.GetComponentInChildren<MeshRenderer> ().enabled;

					if (perc > 1) {
						gameObject.transform.position = endpos;
						Variables.jetPack = false;
						Variables.rawSpeed = SpeedController.currentSpeed;
						perc = 0;
						end = false;
						transition = false;
						safe = true;

						Destroy (CollectObject.jetPack, 0);
					}
				}
			}
		} else if (Variables.playing && !Variables.jetPack && safe) {
			distance += Variables.speed;
			gameObject.GetComponentInChildren<MeshRenderer> ().enabled = !gameObject.GetComponentInChildren<MeshRenderer> ().enabled;
			
			if (distance > 10) {
				gameObject.GetComponentInChildren<MeshRenderer> ().enabled = enabled;
				safe = false;
				distance = 0;
			}
		}
	}
}
