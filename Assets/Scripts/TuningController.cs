using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TuningController : MonoBehaviour {
	public static TuningController Instance;

	void Awake () {
		Global.RetrieveSettings();
		Global.SaveSettings();
		Instance = this;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Attempts to save the settings
	public bool TrySaveSettings () {
		if (ValidSettings()) {

			return true;
		} else {
			return false;
		}
	}
	// Saves the settings of the game
	public void SaveSettings (float GameLength, float RedFondTimeThreshold, int GridWidth, int GridHeight, string StartButtonText, string TuningButtonText) {
		Global.SaveSettings(GameLength, RedFondTimeThreshold, GridWidth, GridHeight, StartButtonText, TuningButtonText);
	}

	// Checks whether all settings are valid
	public bool ValidSettings () {
		foreach (KeyValuePair<string, TuningVariable> tuningVar in TuningVariable.AllTuningVariables) {
			if (!tuningVar.Value.validValue(tuningVar.Value.GetValue())) {
				return false;
			}
		}

		return true;
	}

}
