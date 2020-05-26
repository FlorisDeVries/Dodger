using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI handler, updates displayed info 
/// </summary>
public class UISystem : MonoBehaviour {

	public Canvas gameOver, inGame, pause;

	// In-Game Elements
	public Text waveCounter, waveTimer, bestWave;

	// GameOver Elements
	public Text score, highScore, newHighScore;

	// Other
	public static bool swap;
	private int best;



	void Start() {
		best = GameManager.GetHighScore();
		gameOver.enabled = false;
		swap = false;
		pause.enabled = false;
	}

	void Update() {
		if(GameManager.gameOver && swap)
			RenderGameOver();
		else
			RenderInGame();
		if(swap){
			gameOver.enabled = !gameOver.enabled;
			inGame.enabled = !inGame.enabled;
			swap = false;
		}
	}

	private void RenderGameOver(){
		// Assign values
		int sc = WaveManager.Wave;
		if(best < WaveManager.Wave){
			newHighScore.enabled = true;
			best = sc;
			GameManager.NewHighScore(sc);
		} else
			newHighScore.enabled = false;
		score.text = WaveManager.Wave.ToString();
		highScore.text = best.ToString();
	}

	private void RenderInGame(){
		// Assign values
		waveCounter.text = WaveManager.Wave.ToString();
		waveTimer.text = (WaveManager.Timer + 1).ToString(); // Plus 1 so visual time matches actual time
		bestWave.text = best.ToString();
	}
}
