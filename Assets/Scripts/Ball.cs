using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class for all balls(except player)
/// </summary>
public class Ball : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 startForce;
	private SpriteRenderer render;
	private CircleCollider2D col;
	
	/// <summary>
	/// Using awake to GetComponents, this way they are assigned in time for Spawn to be called
	/// </summary>
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		render = GetComponent<SpriteRenderer>();
		col = GetComponent<CircleCollider2D>();
	}

	/// <summary>
	/// Handling collisions
	/// </summary>
	void OnCollisionEnter2D(Collision2D col) {
		if(GameManager.gameOver)
			return;
		if(col.collider.tag == "Player"){
			col.gameObject.GetComponent<Player>().Hit();
		}
	}

	/// <summary>
	/// Gives the player a warning while spawning the ball
	/// </summary>
	public IEnumerator Spawn(Vector2 force){
		col.enabled = false;
		Vector2 pos = rb.position;
		for(int i = 0; i < 2; i++){
			render.enabled = false;
			yield return new WaitForSeconds(.2f);
			render.enabled = true;
			rb.position = pos;
			for(int j = 0; j < 4; j++){
				yield return new WaitForSeconds(.05f);
				rb.position += force / 8;
			}
			rb.position = pos;
			yield return new WaitForSeconds(.2f);
		}
		col.enabled = true;
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	
}
