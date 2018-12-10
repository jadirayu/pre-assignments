using System.Collections;
using UnityEngine;

public class BrickStone : MonoBehaviour {

	public GameObject BrickStoneParticle;

	void OnCollisionEnter(Collision col){
		Instantiate (BrickStoneParticle, transform.position, Quaternion.identity);
		GM.Instance.DestroyBrick ();
		Destroy (gameObject);
		//TODO add to score
	}
}
