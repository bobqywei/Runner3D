using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public GameObject tile, TileArray;
	public static float farright;
	public static float farleft;
	float aX;

	void Update ()
	{
		if (Variables.playing && Variables.gameMode == 2 && !CameraFollow.transition) {
			aX = Input.acceleration.x;

			if (Mathf.Abs (aX) >= 0.1) {
				if (aX > 0) {
					transform.position = new Vector3 (transform.position.x + Variables.speed / (Variables.rawSpeed / 2.5f), transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (transform.position.x - Variables.speed / (Variables.rawSpeed / 2.5f), transform.position.y, transform.position.z);
				}
			}

			if (Input.GetButton ("left")) {
				transform.position = new Vector3 (transform.position.x - Variables.speed / (Variables.rawSpeed / 4), transform.position.y, transform.position.z); 
			} else if (Input.GetButton ("right")) {
				transform.position = new Vector3 (transform.position.x + Variables.speed / (Variables.rawSpeed / 4), transform.position.y, transform.position.z); 
			}


			if (transform.position.x < farleft) {
				farleft -= 1;
				farright -= 1;

				for (int i = 0; i < Variables.tileArray.Count; i++) {
					Variables.tileArray [i].Insert (0, Instantiate (tile) as GameObject);
					Variables.tileArray [i] [0].transform.parent = TileArray.transform;
					Variables.tileArray [i] [0].transform.position = new Vector3 (farleft - 5, 0.5f, Variables.tileArray [i] [Variables.tileArray [i].Count - 1].transform.position.z); 

					Destroy (Variables.tileArray [i] [Variables.tileArray [i].Count - 1], 0);
					Variables.tileArray [i].RemoveAt (Variables.tileArray [i].Count - 1);
				}
			}

			if (transform.position.x > farright) {
				farright += 1;
				farleft += 1;
				
				for (int i = 0; i < Variables.tileArray.Count; i++) {
					Variables.tileArray [i].Add (Instantiate (tile) as GameObject);
					Variables.tileArray [i] [Variables.tileArray [i].Count - 1].transform.parent = TileArray.transform;
					Variables.tileArray [i] [Variables.tileArray [i].Count - 1].transform.position = new Vector3 (farright + 5, 0.5f, Variables.tileArray [i] [0].transform.position.z); 
					
					Destroy (Variables.tileArray [i] [0], 0);
					Variables.tileArray [i].RemoveAt (0);
				}

			}
		} else if (Variables.playing && Variables.gameMode == 3 && !CameraFollow.transition) {
			if (SystemInfo.deviceType == DeviceType.Desktop) {
				if (Input.GetButton ("up") && gameObject.transform.position.y <= 2.4) {
					transform.position = new Vector3 (transform.position.x, transform.position.y + Variables.speed, transform.position.z);
					GameMode.jeteffect1.GetComponent<ParticleSystem> ().enableEmission = true;
					GameMode.jeteffect2.GetComponent<ParticleSystem> ().enableEmission = true;
				} else if (Input.GetButton ("up") && gameObject.transform.position.y > 2.4) {
					GameMode.jeteffect1.GetComponent<ParticleSystem> ().enableEmission = true;
					GameMode.jeteffect2.GetComponent<ParticleSystem> ().enableEmission = true;
				} else {
					transform.position = new Vector3 (transform.position.x, transform.position.y - Variables.speed, transform.position.z);
					GameMode.jeteffect1.GetComponent<ParticleSystem> ().enableEmission = false;
					GameMode.jeteffect2.GetComponent<ParticleSystem> ().enableEmission = false;
				}
			} else {
				if (Input.touchCount > 0) {
					foreach (Touch touch in Input.touches) {
						if (touch.phase != TouchPhase.Ended || touch.phase != TouchPhase.Canceled) {
							if (gameObject.transform.position.y <= 2.4) {
								transform.position = new Vector3 (transform.position.x, transform.position.y + Variables.speed, transform.position.z);
								GameMode.jeteffect1.GetComponent<ParticleSystem> ().enableEmission = true;
								GameMode.jeteffect2.GetComponent<ParticleSystem> ().enableEmission = true;
							} else {
								GameMode.jeteffect1.GetComponent<ParticleSystem> ().enableEmission = true;
								GameMode.jeteffect2.GetComponent<ParticleSystem> ().enableEmission = true;
							}
						}
					}
				} else {
					transform.position = new Vector3 (transform.position.x, transform.position.y - Variables.speed, transform.position.z);
					GameMode.jeteffect1.GetComponent<ParticleSystem> ().enableEmission = false;
					GameMode.jeteffect2.GetComponent<ParticleSystem> ().enableEmission = false;
				}
			}
		}
	}
}
