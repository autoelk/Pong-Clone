using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public int speed = 75;
	private GameObject paddle1;
	private Paddle paddle1script;
	private GameObject paddle2;
	private Paddle paddle2script;
	private GameObject restartButton;
	private SpriteRenderer ballRender;
	public Text score1;
	public Text score2;
	int winner = 1;

	// Use this for initialization
	void Start () {
		paddle1 = GameObject.Find ("Paddle 1");
		paddle1script = paddle1.GetComponent<Paddle> ();
		paddle2 = GameObject.Find ("Paddle 2");
		paddle2script = paddle2.GetComponent<Paddle> ();
		ballRender = gameObject.GetComponent<SpriteRenderer> ();
		restartButton = GameObject.Find ("Restart");
		ResetGame ();
		ShootBall ();
	}

	public void ResetGame () {
		restartButton.SetActive (false);
		Time.timeScale = 1;
		paddle1script.score = 0;
		score1.text = "0";
		paddle2script.score = 0;
		score2.text = "0";
	}

	void ShootBall () {
		this.transform.position = Vector3.zero;
		this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		if (winner == 1) {
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed, Random.Range (-45, 45)));
		} else {
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-speed, Random.Range (-45, 45)));
		}
	}

	private void OnCollisionEnter2D (Collision2D other) {
		Debug.Log (other.collider.gameObject.name);
		if (other.collider.gameObject.name == "Goal 1") {
			paddle2script.score++;
			score2.text = paddle2script.score.ToString ();
			Debug.Log (paddle2script.score);
			winner = 2;
			if (paddle2script.score >= 10) {
				score2.text = "WIN";
				Time.timeScale = 0;
				restartButton.SetActive (true);
			}
			ShootBall ();
		}
		if (other.collider.gameObject.name == "Goal 2") {
			paddle1script.score++;
			score1.text = paddle1script.score.ToString ();
			Debug.Log (paddle1script.score);
			winner = 1;
			if (paddle1script.score >= 10) {
				score1.text = "WIN";
				Time.timeScale = 0;
				restartButton.SetActive (true);
			}
			ShootBall ();
		}
	}
}