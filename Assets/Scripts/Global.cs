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
	// Default values
	public const float DEFAULT_GAME_LENGTH = 10f;
	public const float DEFAULT_RED_FONT_TIME = 5f;
	public const int DEFAULT_GRID_WDITH = 8;
	public const int DEFAULT_GRID_HEIGHT = 5;
	public const string DEFAULT_START_BUTTON_TEXT = "Start";
	public const string DEFAULT_TUNING_BUTTON_TEXT = "Tuning Variables";

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
		GameLength = PlayerPrefs.GetFloat(GameLengthKey, DEFAULT_GAME_LENGTH);
		RedFontTime = PlayerPrefs.GetFloat(RedFontTimeThresholdKey, DEFAULT_RED_FONT_TIME);
		GridWidth = PlayerPrefs.GetInt(GridWidthKey, DEFAULT_GRID_WDITH);
		GridHeight = PlayerPrefs.GetInt(GridHeightKey, DEFAULT_GRID_HEIGHT);
		StartButtonText = PlayerPrefs.GetString(StartButtonTextKey, DEFAULT_START_BUTTON_TEXT);
		TuningButtonText = PlayerPrefs.GetString(TuningButtonTextKey, DEFAULT_TUNING_BUTTON_TEXT);
	}

	public static void ResetSettingsToDefault () {
		PlayerPrefs.SetFloat(GameLengthKey, DEFAULT_GAME_LENGTH);
		PlayerPrefs.SetFloat(RedFontTimeThresholdKey, DEFAULT_RED_FONT_TIME);
		PlayerPrefs.SetInt(GridWidthKey, DEFAULT_GRID_WDITH);
		PlayerPrefs.SetInt(GridHeightKey, DEFAULT_GRID_HEIGHT);
		PlayerPrefs.SetString(StartButtonTextKey, DEFAULT_START_BUTTON_TEXT);
		PlayerPrefs.SetString(TuningButtonTextKey, DEFAULT_TUNING_BUTTON_TEXT);
		RetrieveSettings();
	}

	public static int GetScore (int BooksRemaining, float TimeRemaining) {
		return (int) ((BooksRemaining + TimeRemaining) * ScoreModifier);
	}
	#endregion
}
