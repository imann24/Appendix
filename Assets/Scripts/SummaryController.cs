using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SummaryController : MonoBehaviour {
	public Text Status;
	public Text Score;
	public Text[] HighScores = new Text[Global.HIGH_SCORE_COUNT];
	public string ScoreString = "Score: ";
	// Use this for initialization
	void Start () {
		Status.text = PlayerPrefs.GetString(Global.GameResultKey)+"!";
		Score.text = ScoreString + PlayerPrefs.GetInt(Global.GameScoreKey);
		SetHighScores();
	}

	// Sets the high score text
	void SetHighScores () {
		int[] scores = Global.RetrieveHighScores();
		for (int i = 0; i < HighScores.Length; i++) {
			if (HighScores == null) {
				continue;
			}

			HighScores[i].text = ScoreText(i, scores[i]);
		}
	}

	string ScoreText (int index, int score) {
		return ((index + 1) + ". " + score);
	}
}
