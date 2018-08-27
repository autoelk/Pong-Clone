using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public int score = 0;
	public int speed = 15;
	private string paddleName;
	private Rigidbody2D rb2D;

	void Start () {
		paddleName = gameObject.name;
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		if (paddleName == "Paddle 1") {
			if (transform.position.y <= 4.08 && Input.GetKey ("w")) {
				rb2D.MovePosition (rb2D.position + new Vector2 (0, speed) * Time.fixedDeltaTime);
			}
			if (transform.position.y >= -4.08 && Input.GetKey ("s")) {
				rb2D.MovePosition (rb2D.position + new Vector2 (0, -speed) * Time.fixedDeltaTime);
			}
		}
		if (paddleName == "Paddle 2") {
			if (transform.position.y <= 4.08 && Input.GetKey ("up")) {
				rb2D.MovePosition (rb2D.position + new Vector2 (0, speed) * Time.fixedDeltaTime);
			}
			if (transform.position.y >= -4.08 && Input.GetKey ("down")) {
				rb2D.MovePosition (rb2D.position + new Vector2 (0, -speed) * Time.fixedDeltaTime);
			}
		}
	}
}