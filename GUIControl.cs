using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {
	public GUIStyle styleLarge, styleMedium;

	void OnGUI () {
		//Screen.width is calculated from the device settings (on which the app is running)
		GUI.Box (new Rect (Screen.width / 6, 0, 2*Screen.width/3, 40), "" + Variables.score, styleLarge);
		GUI.Box (new Rect (Screen.width / 6, 100, 2*Screen.width/3, 40), "best " + ScoreManager.existingHighScore, styleMedium);
	}
}
