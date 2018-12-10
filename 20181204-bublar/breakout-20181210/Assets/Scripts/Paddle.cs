using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float PaddleSpeed = 1f;
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * PaddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -10f, 10f), -9.5f, 0);
		transform.position = playerPos;
	}

	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);

}
