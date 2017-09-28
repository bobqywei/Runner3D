using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Reset : MonoBehaviour
{
	public GameObject Player, Camera, Path, water, playButton, Menu;
	public static GameObject PlayButton;
	public static bool menuLoaded, menuCreated;
	public static bool tapped;
	Vector3 startPos, endPos;
	float framecount, perc;

	void Update ()
	{
		if (!Variables.playing && !Variables.playAgain) {

			if (!menuCreated) {
				PlayButton = Instantiate(playButton) as GameObject;
				PlayButton.transform.tag = "playbutton";
				PlayButton.transform.parent = Menu.transform;
				PlayButton.transform.Rotate(45, 175, 0);
				PlayButton.transform.position = new Vector3(0.325F + Menu.transform.position.x, 6, -7F);

				menuCreated = true;
			}

			if (!menuLoaded) {
				startPos = PlayButton.transform.position;
				endPos = new Vector3 (PlayButton.transform.position.x, 4.5F, -7F);

				framecount += 1;
				perc = framecount * (2 * Time.smoothDeltaTime);
				PlayButton.transform.position = Vector3.Lerp (startPos, endPos, perc);

				if (perc >= 1) {
					framecount = 0;
					menuLoaded = true;
				}

			} else {

				if (Input.GetButtonDown ("down")) {
					tapped = true;
				}

				if (tapped) {


					startPos = PlayButton.transform.position;
					endPos = new Vector3 (PlayButton.transform.position.x, 6, PlayButton.transform.position.z);
					
					framecount += 1;
					perc = framecount * (2 * Time.smoothDeltaTime);
					PlayButton.transform.position = Vector3.Lerp (startPos, endPos, perc);

					if (perc >= 1) {

						Variables.gameMode = 1;
						GameMode.mode = 1;
						GameMode.modeTransition = false;
						
						Camera.transform.position = new Vector3(0.5f, 6, -9);
						Camera.transform.eulerAngles = new Vector3(45, 355, 0);

						Variables.score = 0;
						ScoreManager.score = 0;
						Variables.coins = 0;

						Destroy (PlayButton, 0);

						framecount = 0;
						menuCreated = false;
						menuLoaded = false;
						Variables.playAgain = true;
						menuLoaded = false;
						tapped = false;

						Menu.transform.position = new Vector3 (0,0,0);

						Player.transform.position = new Vector3 (0, 0, 0);
						Player.transform.Find ("PlayerObject").position = new Vector3 (0, 1.25F, -3);
						Camera.transform.position = new Vector3 (0.5F, 6, -9);
						
						Variables.rawSpeed = 5F;
						Variables.speed = 5F * Time.smoothDeltaTime;
						
						for (int i = 0; i < Variables.pathArray.Count; i++) {
							Destroy (Variables.pathArray [i], 0);
						}

						Variables.pathArray.Clear ();
						Variables.boolArray.Clear ();
						Variables.lengthArray.Clear ();

						for (int i = 0; i < Variables.tileArray.Count; i++) {
							for (int j = 0; j < Variables.tileArray[i].Count; j++) {
								Destroy (Variables.tileArray[i][j], 0);
							}
						}

						Variables.tileArray.Clear ();
						Variables.tileBool.Clear ();
						
						/*for (int i = 0; i < Variables.waterblockArray.Count; i++) {
							Destroy (Variables.waterblockArray [i], 0);
						}
						Variables.waterblockArray.Clear ();
						Variables.waterGeneration.Clear ();*/
						
						for (int i = 0; i < Variables.objArray.Count; i++) {
							Destroy (Variables.objArray [i], 0);
						}
						Variables.objArray.Clear ();
						Variables.objType.Clear ();
						
						/*Variables.waterblockArray.Add (Instantiate (water) as GameObject);
						Variables.waterblockArray [Variables.waterblockArray.Count - 1].transform.position = new Vector3 (0, -0.25F, 2);
						Variables.waterGeneration.Add (false);*/
						
						Variables.pathArray.Add (Instantiate (Path) as GameObject);
						Variables.boolArray.Add (true);
						Variables.lengthArray.Add (4);
						Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, -3);
						
						Variables.pathArray.Add (Instantiate (Path) as GameObject);
						Variables.boolArray.Add (true);
						Variables.lengthArray.Add (4);
						Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 2);
						
						Variables.pathArray.Add (Instantiate (Path) as GameObject);
						Variables.boolArray.Add (true);
						Variables.lengthArray.Add (4);
						Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 7);
						
						Variables.pathArray.Add (Instantiate (Path) as GameObject);
						Variables.boolArray.Add (true);
						Variables.lengthArray.Add (4);
						Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 12);
						
						Variables.pathArray.Add (Instantiate (Path) as GameObject);
						Variables.boolArray.Add (false);
						Variables.lengthArray.Add (4);
						Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 17);


					}
				}
			}

		} else if (!Variables.playing && Variables.playAgain && !DeathCheck.deathanim) {
			Player.transform.position = new Vector3 (0, 0, 0);
			Player.transform.Find ("PlayerObject").position = new Vector3 (0, 1.25F, -3);

			if (Input.GetButtonDown ("down")) {
				Variables.playing = true;
				GameMode.startTime = Time.time;

			} else {
				foreach (Touch touch in Input.touches) {
					if (touch.phase == TouchPhase.Ended) {
						Variables.playing = true;
					}
				}
			}
		}
	}
}
