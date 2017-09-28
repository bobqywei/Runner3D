using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour
{
	public GameObject tile, player, TileArray, Path;
	public static bool modeTransition;
	public static float startTime;
	int timeLimit;
	public static int mode = 1;

	void Start ()
	{
		timeLimit = 8;//Random.Range(25,40);
	}

	void Update ()
	{
		if (Variables.playing) {
			if (Variables.gameMode == 1 && !Variables.jetPack) {
				if (!checkJetPack()) {
					if (Time.time - startTime >= timeLimit && mode == 1) {
						startTime = Time.time;
						timeLimit = Random.Range(10,15);
						modeTransition = true;
						mode = 2;

						for (int i = 0; i < 13; i++) {
							Variables.tileArray.Add(new System.Collections.Generic.List<GameObject> ());
							Variables.tileBool.Add (true);
							for (int j = 0; j < 11; j++) {
								Variables.tileArray[i].Add(Instantiate (tile) as GameObject);
								Variables.tileArray [i][j].transform.parent = TileArray.transform;
								Variables.tileArray [i][j].transform.position = new Vector3 (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x + (j - 5), 0.5f, Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + Variables.lengthArray [Variables.pathArray.Count - 1] / 2 + (i));
							}
						}

						PlayerMove.farleft = Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x;
						PlayerMove.farright = Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x;
					}
				}

				if (mode == 2) {
					if (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x == player.transform.position.x) {
						if (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z - (Variables.lengthArray [Variables.pathArray.Count - 1] / 2 + 0.25) < -3 && Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + (Variables.lengthArray [Variables.pathArray.Count - 1] / 2 + 0.25) > -3) {
							mode = 1;
							CameraFollow.transition = true;
							CameraFollow.initialize = true;

							modeTransition = false;
							Variables.gameMode = 2;

							SpeedController.currentSpeed = Variables.rawSpeed;
							Variables.rawSpeed = 1;

						}
					}
				}
			} else if (Variables.gameMode == 2) {

				if (Time.time - startTime >= timeLimit && mode == 1) {

					startTime = Time.time;
					timeLimit = Random.Range(25,40);
					modeTransition = true;
					mode = 2;

					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.x, 0.5F, Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.z + 2.5f);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.x, 0.5F, Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.z + 7.5f);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.x, 0.5F, Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.z + 12.5f);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.x, 0.5F, Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.z + 17.5f);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (false);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.x, 0.5F, Variables.tileArray[Variables.tileArray.Count-1][5].transform.position.z + 22.5f);
				
				}

				if (mode == 2) {
					if (-3 >= Variables.pathArray[0].transform.position.z - 2) {
						if (player.transform.position.x >= Variables.pathArray[0].transform.position.x - 0.5f && player.transform.position.x <= Variables.pathArray[0].transform.position.x + 0.5f) {

							Variables.gameMode = 1;
							player.transform.position = new Vector3 (Variables.pathArray[0].transform.position.x, player.transform.position.y, player.transform.position.z);

							mode = 1;

							CameraFollow.transition = true;
							CameraFollow.initialize = true;

							modeTransition = false;
							
							SpeedController.currentSpeed = Variables.rawSpeed;
							Variables.rawSpeed = 1;
						}
					}
				}
			}
		
		} else {
			if (Input.GetButtonDown ("down") || Input.touchCount > 1) {
				startTime = Time.time;
			}
		}
	}

	bool checkJetPack ()
	{
		for (int i = 0; i < Variables.objType.Count; i++) {
			if (Variables.objType [i] == 1) {
				return true;
			}
		}
		return false;
	}
}
