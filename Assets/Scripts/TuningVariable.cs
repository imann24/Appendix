/*
 * Should be attached to each user input
 * Sets the texts when its spawned
 * Filters for incorrect values
 * Returns its current value
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TuningVariable : MonoBehaviour {
	private const string TIME_VAR = "Time";
	private const string DIMENSION_VAR = "Grid";
	private const string TEXT_VAR = "Text";

	public static Dictionary<string, TuningVariable> AllTuningVariables = new Dictionary<string, TuningVariable>();
	private InputField inputField;
	private string CurrentValue;
	public delegate bool ValidValue(string value);
	public ValidValue validValue;

	// Use this for initialization
	void Start () {
		AllTuningVariables.Add(gameObject.name, this);
		inputField = GetComponentInChildren<InputField>();
		AssignValidCheckAndDefaultValue();
	}

	void OnDestroy () {
		AllTuningVariables.Remove(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AssignValidCheckAndDefaultValue () {
		if (gameObject.name.Contains(TIME_VAR)) {
			validValue = ValidTime;
			inputField.text = PlayerPrefs.GetFloat(gameObject.name).ToString();
		} else if (gameObject.name.Contains(DIMENSION_VAR)) {
			validValue = ValidDimension;
			inputField.text = PlayerPrefs.GetInt(gameObject.name).ToString();
		} else if (gameObject.name.Contains(TEXT_VAR)) {
			validValue = ValidButtonLabel;
			inputField.text = PlayerPrefs.GetString(gameObject.name);
		}
	}

	bool ValidDimension (string value) {
		try {
			int.Parse(value);
			return true;
		} catch {
			return false;
		}
	}

	bool ValidButtonLabel (string value) {
		return true;
	}

	bool ValidTime (string value) {
		try {
			float.Parse(value);
			return true;
		} catch {
			return false;
		}
	}

	public string GetValue () {
		return inputField.text;
	}
}
