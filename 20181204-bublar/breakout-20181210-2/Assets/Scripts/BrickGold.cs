using System.Collections;
using UnityEngine;

public class BrickGold : MonoBehaviour {

	public GameObject BrickGoldParticle;

	void OnCollisionEnter(Collision col){
		collisionNr++;
		if (collisionNr > collisionThreshold) {
			Instantiate (BrickGoldParticle, transform.position, Quaternion.identity);
			GM.Instance.DestroyBrick ();
			Destroy (gameObject);
			// TODO add to score
		}
	}

	private int collisionNr = 0;
	private int collisionThreshold = 1;
}
