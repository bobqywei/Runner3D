using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {
	public GUIStyle styleLarge, styleMedium;

	void OnGUI () {
		GUI.Box (new Rect (Screen.width / 6, 0, 2*Screen.width/3, 40), "" + Variables.score, styleLarge);
		GUI.Box (new Rect (Screen.width / 6, 100, 2*Screen.width/3, 40), "best " + ScoreManager.existingHighScore, styleMedium);
	}
}
