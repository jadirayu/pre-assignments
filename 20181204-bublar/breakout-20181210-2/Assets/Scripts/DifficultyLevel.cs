using System.Collections;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour {

	// haven't implemented in GM scripts
	public float BallSpeed{
		get { return ballSpeed;}
		private set{ ballSpeed = value;}
	}
	private float ballSpeed;

	void Awake(){
		posUpLimit = GameObject.Find ("Ceiling").transform.position.y - 1f;
		print ("Upper limit: " + posUpLimit);
		z = GameObject.Find ("Ceiling").transform.position.z;
	}

	/// <summary>
	/// Refresh a new difficult level by generating corresponding bricks 
	/// and optionally resetting ballSpeed (haven't implemented)
	/// </summary>
	/// <param name="levelNr">Level nr.</param>
	/// <param name="brickStonePrefab">Brick stone prefab.</param>
	/// <param name="brickGoldPrefab">Brick gold prefab.</param>
	/// <param name="brickEmeraldPrefab">Brick emerald prefab.</param>
	public void Refresh (int levelNr, GameObject brickStonePrefab, GameObject brickGoldPrefab, GameObject brickEmeraldPrefab) {
		brickStone = brickStonePrefab;
		brickGold = brickGoldPrefab;
		brickEmerald = brickEmeraldPrefab;

		if (levelNr == 1) {
			GenerateBricks (2, 2);
			ballSpeed = 400f;
		} else if (levelNr == 2) {
			GenerateBricks (5, 3);
			ballSpeed = 500f;
		}
		else {
			Debug.Log ("Uncorrect difficulty level");
		}
	}

	/// <summary>
	/// Instantiate and autolayout the bricks by # of BrickGold and BrickEmerald
	/// </summary>
	/// <param name="brickGoldNr">Brick gold nr.</param>
	/// <param name="brickEmeraldNr">Brick emerald nr.</param>
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

	/// <summary>
	/// Gets the position of brick by itsrow and column.
	/// </summary>
	/// <returns>The position brick.</returns>
	/// <param name="row">Row.</param>
	/// <param name="column">Column.</param>
	Vector3 GetPosBrick(int row, int column){
		Vector3 posBrick = new Vector3 ((column - 2) * 2.2f, posUpLimit + (row) * 1.2f, z);
		return posBrick;
	}

	private GameObject brickStone;
	private GameObject brickGold;
	private GameObject brickEmerald;
	private int brickGoldNr;
	private int brickEmeraldNr;
	private float posUpLimit;
	private float z;
	private int[] deckRow = new int[6];
	private int[] deckColumn = new int[5];
}
