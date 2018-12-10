using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float BallInitialVelocity = 600f;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO modify Fire1 keyword to trigger ball movement
		if (Input.GetButtonDown ("Fire1") && !ballInPlay) {
			ballInPlay = !ballInPlay;
			rb.isKinematic = false;
			transform.parent = null;
			rb.AddForce (new Vector3 (BallInitialVelocity, BallInitialVelocity, 0));
		}
	}

	private bool ballInPlay;
	private Rigidbody rb;
}
