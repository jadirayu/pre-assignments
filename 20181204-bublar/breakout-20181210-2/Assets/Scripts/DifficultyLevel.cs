using System.Collections;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour {

	public float BallSpeed{
		get { return ballSpeed;}
		private set{ ballSpeed = value;}	// TODO change public property BallInitialVelocity to private set in GM
	}
	private float ballSpeed;

	void Awake(){
		posUpLimit = GameObject.Find ("Ceiling").transform.position.y - 2f;
	}

	// refresh numbers of each kind of bricks and ballSpeed by the difficulty level
	public void Refresh (int level, GameObject brickStonePrefab, GameObject brickGoldPrefab, GameObject brickEmeraldPrefab) {
		brickStone = brickStonePrefab;
		brickGold = brickGoldPrefab;
		brickEmerald = brickEmeraldPrefab;

		if (level == 1) {
			GenerateBricks (2, 2);
			ballSpeed = 400f;
		} else if (level == 2) {
			GenerateBricks (5, 3);
			ballSpeed = 500f;
		}
		else {
			Debug.Log ("Uncorrect difficulty level");
		}
	}
		
	void GenerateBricks (int brickGoldNr, int brickEmeraldNr){
		// randomize BrickGold and BrickEmerald position (row, column) by a Knuth Shuffle
		for (int i = 0; i < 6; i++){
			int j = Random.Range (0, i + 1);
			deckRow [i] = deckRow [j];
			deckRow [j] = i;
		}
		for (int i = 0; i < 5; i++){
			int j = Random.Range (0, i + 1);
			deckColumn [i] = deckColumn [j];
			deckColumn [j] = i;
		}

		// instantiate bricks to their randomized positions
		for (int r = 0; r < 6; r++){
			for (int c = 0; c < 5; c++) {
				Vector3 posBrick = GetPosBrick (r, c);
				if (deckRow [r] == 0) {
					if (deckColumn [c] < brickGoldNr) {
						Instantiate (brickGold, posBrick, Quaternion.identity);
					} else if (deckColumn [c] < brickGoldNr + brickEmeraldNr) {
						Instantiate (brickEmerald, posBrick, Quaternion.identity);
					} else {
						Instantiate (brickStone, posBrick, Quaternion.identity);
					}
				} else {
					Instantiate (brickStone, posBrick, Quaternion.identity);
				}
			}
		}
	}

	Vector3 GetPosBrick(int row, int column){
		Vector3 posBrick = new Vector3 ((column - 3) * 2.2f, posUpLimit - (row + 1) * 1.2f, 0);
		return posBrick;
	}

	private GameObject brickStone;
	private GameObject brickGold;
	private GameObject brickEmerald;
	private int brickGoldNr;
	private int brickEmeraldNr;
	private float posUpLimit;
	private int[] deckRow = new int[6];
	private int[] deckColumn = new int[5];
}
