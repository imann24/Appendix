using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {
	public delegate void WinAction (bool victorious, int score);
	public static event WinAction OnWin;


	public static int UnclickedBooks;
	public static bool Clickable {get; private set;}
	public bool IsAppendix {get; private set;}

	public Color IsAppendixColor = Color.green;
	public Color IsNotAppendixColor = Color.red;

	private Material myMaterial;

	// Use this for initialization
	void Start () {
		Clickable = true;
		myMaterial = GetComponent<MeshRenderer>().material;
	}

	void OnMouseDown () {
		if (Clickable) {
			CheckBook();
		}
	}

	// Sets this book to be the appendix
	public void SetAppendix () {
		IsAppendix = true;
	}

	// Checks whether this book is the appendix
	public void CheckBook () {
		// Breaks out of the loop if the game is over
		if (GameController.Instance.GameOver) {
			return;
		}

		if (IsAppendix) {
			myMaterial.color = IsAppendixColor;
			Clickable = false;
			if (OnWin != null) {
				StartCoroutine(TriggerOnWin());
			}
		} else {
			UnclickedBooks--;
			myMaterial.color = IsNotAppendixColor;
		}
	}

	// Triggers the win event
	IEnumerator TriggerOnWin () {
		yield return new WaitForSeconds(0.5f);

#if UNITY_WEBGL
		GameController.Instance.SaveSession(true,Global.GetScore(UnclickedBooks, GameController.Instance.SecondsRemaining));
		ButtonController.Instance.LoadSummaryScreen();
#else
		if (OnWin != null) {
			OnWin(true, (Global.GetScore(UnclickedBooks, GameController.Instance.SecondsRemaining)));
		}
#endif

		ButtonController.Instance.LoadSummaryScreen();
	}
}
