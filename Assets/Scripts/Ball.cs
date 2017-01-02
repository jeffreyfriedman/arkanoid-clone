using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
				// Lock the ball position relative to the paddle
				this.transform.position = paddle.transform.position + paddleToBallVector;

			// Launch on mouse click
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}	
	}

	void OnCollisionEnter2D (Collision2D collision) {
	// Boing sound played on every collision is irritating
//		if (hasStarted) {
//			GetComponent<AudioSource> ().Play ();
//		}
	}
}
