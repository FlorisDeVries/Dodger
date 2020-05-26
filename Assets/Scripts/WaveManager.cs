using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wave manager to keep track of the waves
/// </summary>
public class WaveManager : MonoBehaviour {

	private static int waveCounter;
	public int startingWave = 1;
	public int maxWave;

	public static int Wave{
		get { return waveCounter; }
	}

	public static int Timer{
		get { return (int)timer; }
	}

	private static float timer;

	public float timeBetween = 10f;

	void Start() {
		timer = timeBetween;
		waveCounter = startingWave;
	}

	private void Update() {
		if(GameManager.gameOver && !(waveCounter < maxWave))
			return;
		timer -= Time.deltaTime;
		if(timer < 0)
			NextWave();
	}

	public static void Reset(){
		waveCounter = 1;
	}

	private void NextWave(){
		if(maxWave == 0 || (waveCounter < maxWave && GameManager.gameOver))
			waveCounter++;
		timer = timeBetween;
	}
}
