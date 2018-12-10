using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float PaddleSpeed = 1f;

	void Awake(){
		wallLeft = GameObject.Find ("WallLeft");
		wallRight = GameObject.Find ("WallRight");
	}
	
	// Update is called once per frame
	void Update () {
		float paddlePosX = transform.position.x + (Input.GetAxis ("Horizontal") * PaddleSpeed);
		paddlePos = new Vector3 (Mathf.Clamp (paddlePosX, wallLeft.transform.position.x + 2f, wallRight.transform.position.x - 2f), -10f, 0);	//TODO scale wall according to screen size
		transform.position = paddlePos;

	}

	private Vector3 paddlePos = new Vector3 (0, -10f, 0);
	private GameObject wallLeft;
	private GameObject wallRight;
}
