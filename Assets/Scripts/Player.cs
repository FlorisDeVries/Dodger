using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for a basic player
/// </summary>
public class Player : MonoBehaviour {
	public float speed = 4f;
	//private Vector2 dir;
	private Vector2 target;
	private Vector2 startMove;

	public Rigidbody2D rb;

	void Update () {
		if(GameManager.gameOver)
			return;

		// Enables controls to be done anywhere on the screen
		if(InputManager.GetClick()){
			startMove = InputManager.GetCursorScreenPosition();
			startMove -= rb.position;
		}

		// If cursor or touch down, goto location
		if(InputManager.MouseDown()){
			target = InputManager.GetCursorScreenPosition();
			target -= startMove;
			rb.MovePosition(Vector2.Lerp(rb.position, target, speed * Time.deltaTime));
			rb.velocity = Vector2.zero;
			rb.angularDrag = 0;
		}
	}

	public void Hit(){
		GameManager.GameOver();
	}
}
