using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 400f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && (!ballInPlay)) {
			ballInPlay = !ballInPlay;
			transform.parent = null;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (ballInitialVelocity, ballInitialVelocity, 0));
		}
	}

	private Rigidbody rb;
	private bool ballInPlay;
}
