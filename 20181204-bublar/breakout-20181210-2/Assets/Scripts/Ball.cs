using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float BallInitialVelocity = 600f;
	public GameObject DeathParticle;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO use something else triggering ball movement
		if (Input.GetKeyDown ("space") && !ballInPlay) {
			ballInPlay = !ballInPlay;
			rb.isKinematic = false;
			transform.parent = null;
			rb.AddForce (new Vector3 (BallInitialVelocity, BallInitialVelocity * 2f, 0));
			Instantiate (DeathParticle, transform.position, Quaternion.identity);	
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Paddle(Clone)") {
			rb.AddForce (new Vector3 (50f, 300f, 0));
		}
	}

	private bool ballInPlay;
	private Rigidbody rb;
}
