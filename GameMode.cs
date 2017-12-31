using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour
{
	public GameObject tile, player, TileArray, Path, jetPack, jetEffect, tower;
	public static GameObject jetpack, jeteffect1, jeteffect2;
	public static bool modeTransition, ignoreSequence;
	public static float startTime;
	public static int timeLimit;
	public static int mode = 0;

	Vector3 startPos, endPos;
	float perc;
	bool drop = false;

	void Start ()
	{
		timeLimit = Random.Range(15,20);
	}

	void Update ()
	{
		if (Variables.playing) {
			if (Variables.gameMode == 1 && !Variables.jetPack) {
				if (!checkJetPack ()) {
					if (Time.time - startTime >= timeLimit && mode == 0) {
						startTime = Time.time;
						timeLimit = Random.Range (15, 20);
						modeTransition = true;
						mode = Random.Range (2, 4);
						CameraFollow.mode = mode;

						if (mode == 2) {
							for (int i = 0; i < 13; i++) {
								Variables.tileArray.Add (new System.Collections.Generic.List<GameObject> ());
								Variables.tileBool.Add (true);
								for (int j = 0; j < 11; j++) {
									Variables.tileArray [i].Add (Instantiate (tile) as GameObject);
									Variables.tileArray [i] [j].transform.parent = TileArray.transform;
									Variables.tileArray [i] [j].transform.position = new Vector3 (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x + (j - 5), 0.5f, Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + Variables.lengthArray [Variables.pathArray.Count - 1] / 2 + (i));
								}
							}

							PlayerMove.farleft = Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x;
							PlayerMove.farright = Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x;
						} else if (mode == 3) {
							jetpack = Instantiate (jetPack) as GameObject;
							jetpack.transform.position = new Vector3 (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x, 1.2f, Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + Variables.lengthArray [Variables.lengthArray.Count - 1] / 3);
						}
					}
				}

				if (mode == 2) {
					if (!Variables.jumped && !Variables.straightJump) {
						if (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x == player.transform.position.x) {
							if (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z - (Variables.lengthArray [Variables.pathArray.Count - 1] / 2 + 0.25) < -3 && Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + (Variables.lengthArray [Variables.pathArray.Count - 1] / 2 + 0.25) > -3) {
								mode = 0;
								CameraFollow.transition = true;
								CameraFollow.initialize = true;

								modeTransition = false;
								Variables.gameMode = 2;

								SpeedController.currentSpeed = Variables.rawSpeed;
								Variables.rawSpeed = 1;

							}
						}
					}
				} else if (mode == 3) {

					jetpack.transform.position = new Vector3 (jetpack.transform.position.x, jetpack.transform.position.y, jetpack.transform.position.z - Variables.speed); 

					if (!Variables.jumped && !Variables.straightJump) {
						if (player.transform.position.x == jetpack.transform.position.x) {
							if (jetpack.transform.position.z - 0.5 < -3 && jetpack.transform.position.z + 0.5 > -3) {
								mode = 0;
								CameraFollow.transition = true;
								CameraFollow.initialize = true;

								modeTransition = false;
								Variables.gameMode = 3;

								jetpack.transform.position = new Vector3 (player.transform.position.x, 1.15f, -3.35f);
								jetpack.transform.parent = player.transform;

								jeteffect1 = Instantiate (jetEffect) as GameObject;
								jeteffect1.transform.position = new Vector3 (player.transform.position.x - 0.1F, 0.85F, -3.35F);
								jeteffect1.transform.parent = player.transform;

								jeteffect2 = Instantiate (jetEffect) as GameObject;
								jeteffect2.transform.position = new Vector3 (player.transform.position.x + 0.1F, 0.85F, -3.35F);
								jeteffect2.transform.parent = player.transform;

								SpeedController.currentSpeed = Variables.rawSpeed;
								Variables.rawSpeed = 1;
							}
						}
					}
				}
			} else if (Variables.gameMode == 2 || Variables.gameMode == 3) {

				if (Time.time - startTime >= timeLimit && mode == 0) {

					startTime = Time.time;
					timeLimit = Random.Range (15, 20);
					modeTransition = true;
					mode = 1;

					GameObject obj = null; 
					float zValue = 0;

					if (Variables.gameMode == 2) {
						obj = Variables.tileArray [Variables.tileArray.Count - 1] [5];
						zValue = 2.5f;
					} else if (Variables.gameMode == 3) {
						if (Variables.towerArrayLower.Count > 0) {
							obj = Variables.towerArrayLower [Variables.towerArrayLower.Count - 1];
							zValue = 15f;
						}
					}

					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (obj.transform.position.x, 0.5F, obj.transform.position.z + zValue);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (obj.transform.position.x, 0.5F, obj.transform.position.z + zValue + 5);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (obj.transform.position.x, 0.5F, obj.transform.position.z + zValue + 10);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (true);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (obj.transform.position.x, 0.5F, obj.transform.position.z + zValue + 15);
					
					Variables.pathArray.Add (Instantiate (Path) as GameObject);
					Variables.boolArray.Add (false);
					Variables.lengthArray.Add (4);
					Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (obj.transform.position.x, 0.5F, obj.transform.position.z + zValue + 20);
				
				}

				if (mode == 1) {
					if (-3 >= Variables.pathArray [0].transform.position.z - 2) {
						if (Variables.gameMode == 2) {
							if (player.transform.position.x >= Variables.pathArray [0].transform.position.x - 0.5f && player.transform.position.x <= Variables.pathArray [0].transform.position.x + 0.5f) {
								ignoreSequence = true;

								Variables.gameMode = 1;

								mode = 0;

								CameraFollow.transition = true;
								CameraFollow.initialize = true;

								modeTransition = false;
							
								SpeedController.currentSpeed = Variables.rawSpeed;
								Variables.rawSpeed = 1;

							}
						} else if (Variables.gameMode == 3) {

							if (player.transform.position.y >= 0) {
								Variables.gameMode = 1;
								
								mode = 0;
								
								CameraFollow.transition = true;
								CameraFollow.initialize = true;
								
								modeTransition = false;
								
								SpeedController.currentSpeed = Variables.rawSpeed;
								Variables.rawSpeed = 1;

							} else {

								if (!drop) {
									startPos = player.transform.position;
									endPos = new Vector3(player.transform.position.x, -7.35f, player.transform.position.z);
									drop = true;
								}

								perc += Variables.speed/5;
								player.transform.position = Vector3.Lerp (startPos, endPos, perc); 

								if (perc >= 0.9) {
									perc = 0;

									Destroy (GameMode.jetpack,0);
									Destroy (GameMode.jeteffect1,0);
									Destroy (GameMode.jeteffect2,0);

									Variables.playing = false;
									Variables.playAgain = false;

									drop = false;
								}
							}
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
