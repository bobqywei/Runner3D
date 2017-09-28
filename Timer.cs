using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	/*public GameObject volcanoEffect, player;
	public static GameObject effect;
	bool exploded;
	public static float startTime;
	
	void Update ()
	{
		if (Variables.playing) {
			if (Time.time - startTime >= 1 && !Variables.jetPack) {
				Variables.timer -= 1;
				startTime = Time.time;
			}
			if (Variables.timer == 0) {
				startTime = Time.time;
				effect = Instantiate (volcanoEffect) as GameObject;
				effect.transform.position = new Vector3 (player.transform.position.x, 2, -10);
				Destroy (effect, 8);
				Variables.playing = false;
				exploded = true;
			}
		} else {
			if (Variables.playAgain && exploded) {
				if (Time.time - startTime > 2) {
					Variables.playAgain = false;
					exploded = false;

					player.transform.position = new Vector3 (player.transform.position.x, -2, 0);

					for (int i = 0; i < Variables.pathArray.Count; i++) {
						Destroy (Variables.pathArray [i], 0);
					}
					Variables.pathArray.Clear ();
					Variables.boolArray.Clear ();
					Variables.lengthArray.Clear ();

					for (int i = 0; i < Variables.objArray.Count; i++) {
						Destroy (Variables.objArray [i], 0);
					}
					Variables.objArray.Clear ();
					Variables.objType.Clear ();
				}

			} else {
				if (Input.GetButtonDown ("down") || Input.touchCount > 1) {
					startTime = Time.time;
				}
			}
		}
	}*/
}
