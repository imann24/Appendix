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
}
