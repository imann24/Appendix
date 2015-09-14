using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class TuningController : MonoBehaviour {
	public static TuningController Instance;

	public Text InvalidSettingsText;

	void Awake () {
		Global.RetrieveSettings();
		Global.SaveSettings();
		Instance = this;
	}
	

	// Attempts to save the settings
	public bool TrySaveSettings () {
		if (ValidSettings()) {
			SaveSettings(float.Parse(TuningVariable.AllTuningVariables[Global.GameLengthKey].GetValue()), 
			             float.Parse(TuningVariable.AllTuningVariables[Global.RedFontTimeThresholdKey].GetValue()),
			             int.Parse(TuningVariable.AllTuningVariables[Global.GridWidthKey].GetValue()),
			             int.Parse(TuningVariable.AllTuningVariables[Global.GridHeightKey].GetValue()),
			             TuningVariable.AllTuningVariables[Global.StartButtonTextKey].GetValue(),
			             TuningVariable.AllTuningVariables[Global.TuningButtonTextKey].GetValue());
			return true;
		} else {
			StartCoroutine(InvalidSettingsErrorMessage());
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

	// Resets all tuning variables to default
	public void ResetValuesToDefault () {
		foreach (KeyValuePair<string, TuningVariable> tuningVar in TuningVariable.AllTuningVariables) {
			tuningVar.Value.AssignValidCheckAndDefaultValue();
		}
		

	}

	// Fades error message in an out when input is incorrect for tuning variables
	IEnumerator InvalidSettingsErrorMessage () {
		float fadeRate = 0.05f;
		float pauseRate = 1.0f;

		Color textColor = InvalidSettingsText.color;
		while (InvalidSettingsText.color.a < 1.0f) {
			InvalidSettingsText.color = new Color(textColor.r, textColor.g, textColor.b, InvalidSettingsText.color.a + fadeRate);
			yield return new WaitForEndOfFrame();
		}

		yield return new WaitForSeconds(pauseRate);
		while (InvalidSettingsText.color.a > 0.0f) {
			InvalidSettingsText.color = new Color(textColor.r, textColor.g, textColor.b, InvalidSettingsText.color.a - fadeRate);
			yield return new WaitForEndOfFrame();
		}
	}
}
