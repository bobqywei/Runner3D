using UnityEngine;
using System.Collections;

public class TowerGeneration : MonoBehaviour
{
	public GameObject tower;
	int gapLength, location;
	
	void Update ()
	{
		if (Variables.playing) {
			for (int i = 0; i < Variables.towerArrayLower.Count; i++) {
				Variables.towerArrayLower [i].transform.position = new Vector3 (Variables.towerArrayLower [i].transform.position.x, Variables.towerArrayLower [i].transform.position.y, Variables.towerArrayLower [i].transform.position.z - Variables.speed);
				Variables.towerArrayUpper [i].transform.position = new Vector3 (Variables.towerArrayUpper [i].transform.position.x, Variables.towerArrayUpper [i].transform.position.y, Variables.towerArrayUpper [i].transform.position.z - Variables.speed);

				if (Variables.gameMode == 3 && !GameMode.modeTransition) {
					if (Variables.towerArrayLower [i].transform.position.z < 15 && !Variables.towerBool [i]) {
						Variables.towerBool [i] = true;

						gapLength = Random.Range (25, 51);
						location = Random.Range (-25, 26);

						Variables.towerArrayLower.Add (Instantiate (tower) as GameObject);
						Variables.towerArrayUpper.Add (Instantiate (tower) as GameObject);
						Variables.towerArrayLower [Variables.towerArrayLower.Count - 1].transform.position = new Vector3 (Variables.towerArrayLower [i].transform.position.x, (location / 10f) - (gapLength / 20f) - 7.5f, 20);
						Variables.towerArrayUpper [Variables.towerArrayUpper.Count - 1].transform.position = new Vector3 (Variables.towerArrayUpper [i].transform.position.x, (location / 10f) + (gapLength / 20f) + 7.5f, 20);
						Variables.towerBool.Add (false);
					}
				}

				if (Variables.towerArrayLower [i].transform.position.z <= -13) {
					Destroy (Variables.towerArrayLower [i], 0);
					Destroy (Variables.towerArrayUpper [i], 0);
					Variables.towerArrayLower.RemoveAt (i);
					Variables.towerArrayUpper.RemoveAt (i);
					Variables.towerBool.RemoveAt (i);

					if (Variables.towerArrayLower.Count > 0) {
						Variables.towerArrayLower [i].transform.position = new Vector3 (Variables.towerArrayLower [i].transform.position.x, Variables.towerArrayLower [i].transform.position.y, Variables.towerArrayLower [i].transform.position.z - Variables.speed);
						Variables.towerArrayUpper [i].transform.position = new Vector3 (Variables.towerArrayUpper [i].transform.position.x, Variables.towerArrayUpper [i].transform.position.y, Variables.towerArrayUpper [i].transform.position.z - Variables.speed);
					}
				}
			}
		}
	}
}
