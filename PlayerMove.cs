using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public GameObject tile, TileArray;

	public static float farright;
	public static float farleft;

	float aX;

	void Update () {
		if (Variables.playing && Variables.gameMode == 2 && !CameraFollow.transition) {
			aX = Input.acceleration.x;

			if (Mathf.Abs(aX) >= 0.2) {
				if (aX > 0) {
					transform.position = new Vector3(transform.position.x + Variables.speed/(Variables.rawSpeed/3), transform.position.y, transform.position.z);
				}
				else {
					transform.position = new Vector3(transform.position.x - Variables.speed/(Variables.rawSpeed/3), transform.position.y, transform.position.z);
				}
			}

			if (Input.GetButton("left")) {
				transform.position = new Vector3(transform.position.x - Variables.speed/(Variables.rawSpeed/4), transform.position.y, transform.position.z); 
			}
			else if (Input.GetButton("right")) {
				transform.position = new Vector3(transform.position.x + Variables.speed/(Variables.rawSpeed/4), transform.position.y, transform.position.z); 
			}


			if (transform.position.x < farleft) {
				farleft -= 1;
				farright -= 1;

				for (int i = 0; i < Variables.tileArray.Count; i++) {
					Variables.tileArray [i].Insert (0, Instantiate (tile) as GameObject);
					Variables.tileArray [i][0].transform.parent = TileArray.transform;
					Variables.tileArray [i][0].transform.position = new Vector3 (farleft - 5, 0.5f, Variables.tileArray [i][Variables.tileArray [i].Count-1].transform.position.z); 

					Destroy (Variables.tileArray [i][Variables.tileArray [i].Count-1],0);
					Variables.tileArray [i].RemoveAt (Variables.tileArray [i].Count-1);
				}
			}

			if (transform.position.x > farright) {
				farright += 1;
				farleft += 1;
				
				for (int i = 0; i < Variables.tileArray.Count; i++) {
					Variables.tileArray [i].Add (Instantiate (tile) as GameObject);
					Variables.tileArray [i][Variables.tileArray [i].Count-1].transform.parent = TileArray.transform;
					Variables.tileArray [i][Variables.tileArray [i].Count-1].transform.position = new Vector3 (farright + 5, 0.5f, Variables.tileArray [i][0].transform.position.z); 
					
					Destroy (Variables.tileArray [i][0],0);
					Variables.tileArray [i].RemoveAt (0);
				}

			}
		}
	}
}
