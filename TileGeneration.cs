using UnityEngine;
using System.Collections;

public class TileGeneration : MonoBehaviour
{
	public GameObject tile;
	int destroy;
	float temp;

	void Update ()
	{
		if (Variables.playing) {
			//if (GameMode.modeTransition) {

				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - Variables.speed);

				for (int i = 0; i < Variables.tileArray.Count; i++) {

					if (Variables.tileArray [i] [Variables.tileArray [i].Count - 1].transform.position.z <= -9) {

						if (!GameMode.modeTransition && Variables.gameMode == 2) {
							Variables.tileArray.Add (new System.Collections.Generic.List<GameObject> ());
							Variables.tileBool.Add (false);
						}

						for (int k = 0; k < Variables.tileArray[i].Count; k++) {

							if (!GameMode.modeTransition && Variables.gameMode == 2) {
								Variables.tileArray [Variables.tileArray.Count - 1].Add (Instantiate (tile) as GameObject);
								Variables.tileArray [Variables.tileArray.Count - 1] [k].transform.parent = transform;
								Variables.tileArray [Variables.tileArray.Count - 1] [k].transform.position = new Vector3 (Variables.tileArray [i] [k].transform.position.x, 0.5f, Variables.tileArray [i] [k].transform.position.z + 13);
							}

							Destroy (Variables.tileArray [i] [k], 0);
						}

						Variables.tileArray.RemoveAt (i);
						Variables.tileBool.RemoveAt (i);
					}

				if (!GameMode.modeTransition && Variables.gameMode == 2) {
					if (Variables.tileArray [i] [Variables.tileArray [i].Count - 1].transform.position.z <= 2 && !Variables.tileBool [i]) {
						Variables.tileBool [i] = true;
						for (int j = 0; j < Variables.tileArray[i].Count - 1; j++) {
							destroy = Random.Range (1, 11);
							if (destroy == 1) {
								Variables.tileArray [i] [j].tag = "FallenTile";
							}
						}
					}
				}
			}
		}
	}
}

