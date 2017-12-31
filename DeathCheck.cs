using UnityEngine;
using System.Collections;

public class DeathCheck : MonoBehaviour
{
	Vector3 startpos, endpos;
	float frameCount, perc;
	public static bool deathanim;
	public GameObject crash;
	public static GameObject crashEffect;

	void Update ()
	{
		if (Variables.playing && Variables.gameMode == 1 && !Variables.jumped && !Variables.straightJump && !Variables.jetPack && !PowerUp.safe && !GameMode.ignoreSequence) {
			if (!checkMode1 ()) {
				Variables.playing = false;
				startpos = gameObject.transform.position;
				endpos = new Vector3 (gameObject.transform.position.x, -20, gameObject.transform.position.z);
				deathanim = true;
			}
		} else if (Variables.playing && Variables.gameMode == 2) {
			if (!checkMode2 ()) {
				Variables.playing = false;
				startpos = gameObject.transform.position;
				endpos = new Vector3 (gameObject.transform.position.x, -20, gameObject.transform.position.z);
				deathanim = true;
			}
		} else if (Variables.playing && Variables.gameMode == 3) {
			if (!checkMode3 () || !checkMode4 ()) {
				if (!checkMode4()) {
					gameObject.transform.GetComponentInChildren<MeshRenderer> ().enabled = false;
					crashEffect = Instantiate (crash) as GameObject;
					crashEffect.transform.position = new Vector3(transform.position.x, transform.position.y + 1.25f, -3);
				}

				Destroy (GameMode.jetpack, 0);
				Destroy (GameMode.jeteffect1, 0);
				Destroy (GameMode.jeteffect2, 0);

				Variables.playing = false;
				Variables.playAgain = false;
			}
		}

		if (deathanim) {

			frameCount += 1;

			if (Variables.gameMode == 1) {
				perc = frameCount * (Variables.speed / 8);
			}
			if (Variables.gameMode == 2) {
				perc = frameCount * (Variables.speed / 16);
			}

			gameObject.transform.position = Vector3.Lerp (startpos, endpos, perc);
			
			if (perc >= 1) {
				frameCount = 0;
				deathanim = false;
				Variables.playAgain = false;
			}
		}
	}

	bool checkMode1 ()
	{
		for (int i = 0; i < Variables.pathArray.Count; i++) {
			if (Variables.pathArray [i].transform.position.x == gameObject.transform.position.x) {
				if (Variables.pathArray [i].transform.position.z - (Variables.lengthArray [i] / 2 + 0.25f) < -3 && Variables.pathArray [i].transform.position.z + (Variables.lengthArray [i] / 2 + 0.25f) > -3) {
					return true;
				}
			}
		}
		return false;
	}

	bool checkMode2 ()
	{
		for (int i = 0; i < Variables.tileArray.Count; i++) {
			for (int j = 0; j < Variables.tileArray [i].Count; j++) {
				if (Variables.tileArray [i] [j].tag != "FallenTile") {
					if (transform.position.x + 0.2f >= Variables.tileArray [i] [j].transform.position.x - 0.5f && transform.position.x - 0.2f <= Variables.tileArray [i] [j].transform.position.x + 0.5f) {
						if (-2.75 >= Variables.tileArray [i] [j].transform.position.z - 0.5f && -3.25 <= Variables.tileArray [i] [j].transform.position.z + 0.5f) {
							return true;
						}
					}
				}
			}
		}
		if (Variables.pathArray.Count > 0) {
			for (int i = 0; i < Variables.pathArray.Count; i++) {
				if (transform.position.x >= Variables.pathArray[i].transform.position.x - 0.5f && transform.position.x <= Variables.pathArray[i].transform.position.x + 0.5f) {
					if (Variables.pathArray [i].transform.position.z - (Variables.lengthArray [i] / 2 + 0.25f) < -3 && Variables.pathArray [i].transform.position.z + (Variables.lengthArray [i] / 2 + 0.25f) > -3) {
						return true;
					}
				}
			}
		}
		return false;
	}

	bool checkMode3 () 
	{
		if (gameObject.transform.position.y >= -5.9) {
			return true;
		}

		return false;
	}
	
	bool checkMode4 () 
	{
		for (int i = 0; i < Variables.towerArrayLower.Count; i++) {
			if (Variables.towerArrayLower [i].transform.position.z - 0.5f < (-2.75) && Variables.towerArrayLower [i].transform.position.z + 0.5f > (-3 - 0.25f)) {
				if ((transform.position.y + 1.25f) + 0.25f > Variables.towerArrayUpper [i].transform.position.y - 7.5f || (transform.position.y + 1.25f) - 0.25f < Variables.towerArrayLower [i].transform.position.y + 7.5f) {
					return false;
				}
			}
		}
		return true;
	}
}
