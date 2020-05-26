using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that handles basic menu actions(could/should be merged with mainMenu probably)
/// </summary>
public class MenuManager : MonoBehaviour {

	public Canvas inGame, pause;

	public void Restart(){
		GameManager.gameOver = false;
		WaveManager.Reset();
		SceneManager.LoadScene("MainScene");
	}

	public void StartGame(){
		Restart();
	}

	public void GoToMenu(){
		GameManager.UnPause();
		SceneManager.LoadScene("MainMenu");
	}

	public void Exit(){
		Application.Quit();
	}

	public void Pause(){
		GameManager.Pause();
		pause.enabled = true;
		inGame.enabled = false;
	}

	public void UnPause(){
		GameManager.UnPause();
		pause.enabled =  false;
		inGame.enabled = true;
	}
}
