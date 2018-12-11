using System.Collections;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour {

	public GameObject BrickStone;
	public GameObject BrickGold;
	public GameObject BrickEmerald;

	public float BallSpeed{
		get { return ballSpeed;}
		set{ ballSpeed = value;}
	}
	private float ballSpeed;

	// regenerate bricks
	public void RefreshDifficultyLevel () {
		if (Level == 1) {
			BricksAutoLayout (3, 2);
			ballSpeed = 450f;
		} else if (Level == 2) {
			BricksAutoLayout (5, 3);
			ballSpeed = 500f;
		} else if (Level == 3) {
			BricksAutoLayout (8, 5);
			ballSpeed = 600f;
		} else {
			Debug.Log ("Uncorrect difficulty level");
		}
	}

	// randomize bricks layout by difficulty level
	void BricksAutoLayout(int brickGoldNr, int brickEmeraldNr){
		// TODO: generate multiple random numbers
	}

	private int Level = 1;
	private int brickGoldNr;
	private int brickEmeraldNr;
}
