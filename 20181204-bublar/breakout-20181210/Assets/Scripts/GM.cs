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
	public GameObject YouWwon;
	public GameObject BricksPrefab;
	public GameObject Paddle;
	public GameObject DeathParticles;
	public static GM Instance = null;

	// Use this for initialization
	void Awake () {
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);

		Setup ();
		
	}

	public void Setup(){
		clonePaddle = Instantiate (Paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (BricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver(){
		if (Bricks < 1) {
			YouWwon.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", ResetDelay);
		}

		if (Lives < 1) {
			GameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", ResetDelay);
		}
	}

	void Reset(){
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoseLife(){
		Lives--;
		LivesText.text = "Lives: " + Lives;
		Instantiate (DeathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", ResetDelay);
		CheckGameOver ();
	}

	void SetupPaddle(){
		clonePaddle = Instantiate (Paddle, transform.position, Quaternion.identity);
	}

	public void DestroyBrick(){
		Bricks--;
		CheckGameOver ();
	}

	private GameObject clonePaddle;
}
