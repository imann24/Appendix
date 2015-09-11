/*
 * A system of global variables used to store game state info
 * This system is used to load settings and scenes
 */

using UnityEngine;
using System.Collections;

public class Global {

	#region Scenes
	// The scenes names are keys used to load the scenes with the Application.LoadLevel method
	public const string StartScene = "Start";
	public const string GameScene = "Game";
	public const string TuningScene = "Tuning";
	public const string SummaryScene = "Summary";
	#endregion

	#region Settings

	// These are keys used to retreive the saved settings via PlayerPrefs
	public const string GameLengthKey = "GameTime";
	public const string RedFontTimeThresholdKey = "RedFontTimeThreshold";
	public const string GridWidthKey = "GridWidth";
	public const string GridHeightKey = "GridHeight";
	public const string StartButtonTextKey = "StartButtonText";
	public const string TuningButtonTextKey = "TuningButtonText";

	public const string GameScoreKey = "Score";
	public const string GameResultKey = "Result";

	// The setting variables
	public static float ScoreModifier = 10;
	public static float GameLength;
	public static float RedFontTime;
	public static int GridWidth;
	public static int GridHeight;
	public static string StartButtonText;
	public static string TuningButtonText;

	// Saves the settings
	public static void SaveSettings (float GameLength, float RedFontTimeThreshold, int GridWidth, int GridHeight, string StartButtonText, string TuningButtonText) {
		PlayerPrefs.SetFloat(GameLengthKey, GameLength);
		PlayerPrefs.SetFloat(RedFontTimeThresholdKey, RedFontTimeThreshold);
		PlayerPrefs.SetInt(GridWidthKey, GridWidth);
		PlayerPrefs.SetInt(GridHeightKey, GridHeight);
		PlayerPrefs.SetString(StartButtonTextKey, StartButtonText);
		PlayerPrefs.SetString(TuningButtonTextKey, TuningButtonText);
	}

	//Saves the settings to player prefs based of their current values
	public static void SaveSettings () {
		SaveSettings (GameLength, RedFontTime, GridWidth, GridHeight, StartButtonText, TuningButtonText);
	}
	// Retrieves the persistent saved settings
	public static void RetrieveSettings () {
		GameLength = PlayerPrefs.GetFloat(GameLengthKey, 10.0f);
		RedFontTime = PlayerPrefs.GetFloat(RedFontTimeThresholdKey, 5.0f);
		GridWidth = PlayerPrefs.GetInt(GridWidthKey, 8);
		GridHeight = PlayerPrefs.GetInt(GridHeightKey, 5);
		StartButtonText = PlayerPrefs.GetString(StartButtonTextKey, "Start");
		TuningButtonText = PlayerPrefs.GetString(TuningButtonTextKey, "Tuning Variables");
	}

	public static int GetScore (int BooksRemaining, float TimeRemaining) {
		return (int) ((BooksRemaining + TimeRemaining) * ScoreModifier);
	}
	#endregion
}
