using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int LivesNr = 3;
	public int BricksNr = 30;
	public float ResetDelay = 1f;
	public Text LivesText;
	public GameObject GameOver;
	public GameObject YouWon;
	public GameObject Paddle;
	public static GM Instance = null;
	public GameObject BrickStonePrefab;
	public GameObject BrickGoldPrefab;
	public GameObject BrickEmeraldPrefab;

	public int Score = 0; // TODO customize score according to brickStone, gold or emerald

	// Use this for initialization
	void Awake () {
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);

		Setup ();
	}

	public void Setup(){
		SetupPaddle ();
		SetupBricks ();
	}

	void SetupPaddle(){
		clonePaddle = Instantiate (Paddle, new Vector3 (0, -10f, 0), Quaternion.identity) as GameObject;
	}

	// TODO rewrite SetupBricks()
	void SetupBricks(){
		Instantiate (BrickStonePrefab, transform.position, Quaternion.identity);
//		Instantiate (BrickGoldPrefab, transform.position, Quaternion.identity);
//		Instantiate (BrickEmeraldPrefab, transform.position, Quaternion.identity);
	}
		
	void Reset(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void DestroyBrick(){
		BricksNr--;
		CheckGameOver ();
	}

	public void LoseLife(){
		LivesNr--;
		LivesText.text = "Lives: " + LivesNr;
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", ResetDelay);
		CheckGameOver ();
	}

	public void CheckGameOver(){
		if (BricksNr < 1) {
			YouWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", ResetDelay);
		}

		if (LivesNr < 1) {
			GameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", ResetDelay);
		}
	}

	private GameObject clonePaddle;

}
