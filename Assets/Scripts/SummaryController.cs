using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SummaryController : MonoBehaviour {
	public Text Status;
	public Text Score;
	public string ScoreString = "Score: ";
	// Use this for initialization
	void Start () {
		Status.text = PlayerPrefs.GetString(Global.GameResultKey)+"!";
		Score.text = ScoreString + PlayerPrefs.GetInt(Global.GameScoreKey);
	}
}
