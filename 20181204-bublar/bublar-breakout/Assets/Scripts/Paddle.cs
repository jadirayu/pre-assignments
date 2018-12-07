using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float PlayerSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * PlayerSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -3f, 0);
		transform.position = playerPos;		
	}

	private Vector3 playerPos = new Vector3 (0, -3f, 0);
}
