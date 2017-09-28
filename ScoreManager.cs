using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int existingHighScore;
	int coinCount;
	public static float score;

	void Update () {
		if (Variables.playing) {
			if (coinCount < Variables.coins) {
				coinCount = Variables.coins;
				score += 500;
				Variables.score += Random.Range (100, 500);
			}

			score += Variables.speed*5;
			Variables.score = (int) Mathf.Round(score);
			
			if (Variables.score > existingHighScore) {
				PlayerPrefs.SetInt("highscore",Variables.score);
				PlayerPrefs.Save();
			}

		} else {
			if (coinCount > 0) {
				coinCount = 0;
			}
		}

		if (PlayerPrefs.HasKey("highscore")) {
			existingHighScore = PlayerPrefs.GetInt("highscore");
		}
	}
}
