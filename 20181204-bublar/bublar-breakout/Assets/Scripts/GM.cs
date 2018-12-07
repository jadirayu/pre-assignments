using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int Lives = 3;
	public int Bricks = 20;
	public float ResetDelay = 1f;
	public Text LivesText;
	public GameObject GameOver;
	public GameObject YouWon;
	public GameObject BricksPrefab;
	public GameObject Paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Setup ();
		
	}

	void Setup(){
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private GameObject clonePaddle;
}
