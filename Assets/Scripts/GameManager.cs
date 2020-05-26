using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for some basic game management
/// </summary>
public class GameManager : MonoBehaviour {

	new public static Camera camera;

	public static bool gameOver = false;

	void Awake() {
		camera = Camera.main;
	}

	/// <summary>
	/// Called when player loses
	/// </summary>
	public static void GameOver(){
		gameOver = true;
		UISystem.swap = true;
	}

	/// <summary>
	/// Updates HS
	/// </summary>
	/// <param name="score">The new highscore</param>
	public static void NewHighScore(int score){
		PlayerPrefs.SetInt("HighScore", score);
	}

	/// <returns>the current highscore of the player</returns>
	public static int GetHighScore(){
		return PlayerPrefs.GetInt("HighScore");
	}

	public static void Pause(){
		Time.timeScale = 0;
	}

	public static void UnPause(){
		Time.timeScale = 1;
	}
}
