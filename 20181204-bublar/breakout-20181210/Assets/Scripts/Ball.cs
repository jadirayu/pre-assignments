using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float BallInitialVelocity = 600f;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && !ballInPlay) {
			ballInPlay = true;
			transform.parent = null;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (BallInitialVelocity, BallInitialVelocity, 0f));
		}
	}

	private Rigidbody rb;
	private bool ballInPlay;
}
