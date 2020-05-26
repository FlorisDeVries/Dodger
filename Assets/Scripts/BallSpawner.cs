using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that spawns balls
/// </summary>
public class BallSpawner : MonoBehaviour {

	public Ball ballPrefab;
	BoxCollider2D spawnArea;
	Vector2 maxSpawnPos;
	
	List<Ball> balls;

	void Start() {
		spawnArea = GetComponent<BoxCollider2D>();
		maxSpawnPos = new Vector2(spawnArea.bounds.extents.x, spawnArea.bounds.extents.y);

		balls = new List<Ball>();
	}


	void Update () {
		if(balls.Count < 1 + WaveManager.Wave + (WaveManager.Wave / 10))
			SpawnBall();
	}

	/// <summary>
	/// When calles generates a ball
	/// </summary>
	void SpawnBall(){
		// Generate ball at loc.
		Vector2 pos = new Vector2(Random.Range(-maxSpawnPos.x, maxSpawnPos.x) + transform.position.x, Random.Range(-maxSpawnPos.y, maxSpawnPos.y) + transform.position.y);
		Ball spawned = Instantiate(ballPrefab, pos, Quaternion.identity);

		float speed = Random.Range(4, 8);
		StartCoroutine(spawned.Spawn(Random.insideUnitCircle.normalized * speed));


		balls.Add(spawned);
	}
}
