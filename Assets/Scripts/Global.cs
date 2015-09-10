/*
 * A system of global variables used to store game state info
 * This system is used to load settings and scenes
 */

using UnityEngine;
using System.Collections;

public class Global {

	#region Scenes
	public const string StartScene = "Start";
	public const string GameScene = "Game";
	public const string TuningScene = "Tuning";
	public const string SummaryScene = "Summary";
	#endregion

	#region Settings
	public const string GameLengthKey = "GameLength";
	public const string RedFontTimeThresholdKey = "RedFontTime";
	public const string GridWidthKey = "GridWidth";
	public const string GridHeightKey = "GridHeight";
	public const string StartButtonTextKey = "StartButtonText";
	public const string TuningButtonTextKey = "TuningButtonText";

	public static float GameLength;
	public static float RedFontTime;
	public static int GridWidth;
	public static int GridHeight;
	public static string StartButtonText;
	public static string TuningButtonText;

	// Saves the settings
	public static void SaveSettings (float GameLength, float RedFondTimeThreshold, int GridWidth, int GridHeight, string StartButtonText, string TuningButtonText) {
		PlayerPrefs.SetFloat(GameLengthKey, GameLength);
		PlayerPrefs.SetFloat(RedFontTimeThresholdKey, RedFondTimeThreshold);
		PlayerPrefs.SetFloat(GridWidthKey, GridWidth);
		PlayerPrefs.SetFloat(GridHeightKey, GridHeight);
		PlayerPrefs.SetString(StartButtonTextKey, StartButtonText);
		PlayerPrefs.SetString(TuningButtonTextKey, TuningButtonText);
	}

	// Retrieves the persistent saved settings
	public static void RetrieveSettings () {
		GameLength = PlayerPrefs.GetFloat(GameLengthKey, 10.0f);
		RedFontTime = PlayerPrefs.GetFloat(RedFontTimeThresholdKey, 5.0f);
		GridWidth = PlayerPrefs.GetFloat(GridWidthKey, 8);
		GridHeight = PlayerPrefs.GetFloat(GridHeightKey, 5);
		StartButtonText = PlayerPrefs.GetString(StartButtonTextKey, "Start");
		TuningButtonText = PlayerPrefs.GetString(TuningButtonTextKey, "Tuning Variables");
	}

	#endregion
}
