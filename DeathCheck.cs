using UnityEngine;
using System.Collections;

public class DeathCheck : MonoBehaviour
{
	Vector3 startpos, endpos;
	float frameCount, perc;
	public static bool deathanim;

	void Update ()
	{
		if (Variables.playing && Variables.gameMode == 1 && !Variables.jumped && !Variables.straightJump && !Variables.jetPack && !PowerUp.safe) {
			if (!checkDeath ()) {
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

	bool checkDeath ()
	{
		for (int i = 0; i < Variables.pathArray.Count; i++) {
			if (Variables.pathArray [i].transform.position.x == gameObject.transform.position.x) {
				if (Variables.pathArray [i].transform.position.z - (Variables.lengthArray [i] / 2 + 0.25) < -3 && Variables.pathArray [i].transform.position.z + (Variables.lengthArray [i] / 2 + 0.25) > -3) {
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
					if (transform.position.x >= Variables.tileArray [i] [j].transform.position.x - 0.5 && transform.position.x <= Variables.tileArray [i] [j].transform.position.x + 0.5) {
						if (-3 >= Variables.tileArray [i] [j].transform.position.z - 0.5 && -3 <= Variables.tileArray [i] [j].transform.position.z + 0.5) {
							return true;
						}
					}
				}
			}
		}
		if (Variables.pathArray.Count > 0) {
			for (int i = 0; i < Variables.pathArray.Count; i++) {
				if (transform.position.x >= Variables.pathArray[i].transform.position.x - 0.5f && transform.position.x <= Variables.pathArray[i].transform.position.x + 0.5f) {
					if (Variables.pathArray [i].transform.position.z - (Variables.lengthArray [i] / 2 + 0.25) < -3 && Variables.pathArray [i].transform.position.z + (Variables.lengthArray [i] / 2 + 0.25) > -3) {
						return true;
					}
				}
			}
		}
		return false;
	}
}
