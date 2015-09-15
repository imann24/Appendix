using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController Instance;

	// Event for end of game
	public delegate void GameOverAction();
	public static event GameOverAction OnGameOver;
	public bool GameOver {get; private set;}

	public GameObject BookObject;
	public Text Timer;
	public Book[,] Library;
	public float spacing = 2.0f;
	public float SecondsRemaining {get; private set;}
	private float cameraZoom = 1.1f;
	private float clockUpdateRate = 1.0f;
	
	private const string VictoryText = "Victory";
	private const string DefeatText = "Defeat";

	// Use this for initialization
	void Start () {
		Instance = this;

		Global.RetrieveSettings();

		SpawnLibrary();

		AssignAppendix();

		SetCameraSize();

		ResetClock();

		InvokeRepeating("TickClock", clockUpdateRate, clockUpdateRate);

		SubscribeEvents();
	}

	void OnDestroy () {
		UnsubscribeEvents();
	}
	


	// Generates all the books
	void SpawnLibrary () {
		Library = new Book[Global.GridWidth, Global.GridHeight];
		float xOffset = (float) Global.GridWidth/2f * spacing - spacing/2f;
		float yOffset = (float) Global.GridHeight/2f * spacing - spacing/2f;
	
		for (int x = 0; x < Global.GridWidth; x++) {
			for (int y = 0; y < Global.GridHeight; y++) {
				Library[x, y] = ((GameObject)Instantiate(BookObject, new Vector3(x*spacing - xOffset, y*spacing - yOffset), Quaternion.identity)).GetComponent<Book>();
			}
		}

		Book.UnclickedBooks = Global.GridWidth * Global.GridHeight;
	}

	void AssignAppendix () {
		int x = Random.Range(0, Global.GridWidth);
		int y = Random.Range(0, Global.GridHeight);

		Library[x, y].SetAppendix();
	}

	void SetCameraSize () {
		Camera.main.orthographicSize = Mathf.Max(Global.GridWidth, Global.GridHeight) * cameraZoom;
	}

	void ResetClock () {
		SecondsRemaining = Global.GameLength;
		UpdateVisualTime(Global.GameLength.ToString(), false);
	}

	void TickClock () {
		if (GameOver) {
			return;
		}

		SecondsRemaining-=clockUpdateRate;
		UpdateVisualTime(SecondsRemaining.ToString(), SecondsRemaining <= Global.RedFontTime);

		CheckForGameOver ();
	}

	void UpdateVisualTime (string time, bool turnRed) {
		Timer.text = time;

		if (turnRed) {
			Timer.color = Color.red;
		}
	}

	void CheckForGameOver () {
		if (SecondsRemaining <= 0) {
#if UNITY_WEBGL || UNITY_WEBPLAYER
			SaveSession();
			ButtonController.Instance.LoadSummaryScreen();
#else
			if (OnGameOver != null) {
				OnGameOver();
			}
#endif
		}
	}

	void HandleOnGameOver () {
		SaveSession();
	}

	public void SaveSession (bool victory = false, int score = 0) {
		PlayerPrefs.SetString(Global.GameResultKey, victory?VictoryText:DefeatText);
		PlayerPrefs.SetInt(Global.GameScoreKey, score);

		// Adds a high score
		if (Global.IsHighScore(score)) {
			Global.AddHighScore(score);
		}
	}

	void SubscribeEvents () {
		OnGameOver += HandleOnGameOver;
		OnGameOver += ButtonController.Instance.LoadSummaryScreen;
		Book.OnWin += SaveSession;
	}

	void UnsubscribeEvents () {
		OnGameOver -= HandleOnGameOver;
		OnGameOver -= ButtonController.Instance.LoadSummaryScreen;
		Book.OnWin -= SaveSession;
	}
}
