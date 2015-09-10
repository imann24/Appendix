/*
 * Used to perform the functions on the buttons in the game
 * The primary use is for loading new scenes
 */

using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Loads the main game
	public void LoadGame () {
		Application.LoadLevel(Global.GameScene);
	}

	// Loads the start scene
	public void LoadStart () {
		Application.LoadLevel(Global.StartScene);
	}
	
	// Loads the tuning variables
	public void LoadTuningVariables () {
		Application.LoadLevel(Global.TuningScene);
	}

	// Loads the summary screen
	public void LoadSummaryScreen () {
		Application.LoadLevel(Global.SummaryScene);
	}

	/*GameLength = 10 seconds
		RedFontTimeThreshold = 5 seconds
			GridWidth = 8
			GridHeight = 5
			Start button text on Menu screen: “Start”
			Tuning variables button text on Menu screen: “Tuning Variables”*/

	// Saves the settings of the game
	public void SaveSettings (float GameLength, float RedFondTimeThreshold, int GridWidth, int GridHeight, string StartButtonText, string TuningButtonText) {
		//PlayerPrefs.SetFloat(
	}
}
