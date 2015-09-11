using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartController : MonoBehaviour {
	public Text StartButtonText;
	public Text TuningButtonText;
	// Use this for initialization
	void Start () {
		Global.RetrieveSettings();
		SetButtonText();
	}
	
	void SetButtonText () {

		StartButtonText.text = Global.StartButtonText;
		TuningButtonText.text = Global.TuningButtonText;
	}
}
