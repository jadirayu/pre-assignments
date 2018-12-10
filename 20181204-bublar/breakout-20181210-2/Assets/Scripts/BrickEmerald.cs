using System.Collections;
using UnityEngine;

public class BrickEmerald : MonoBehaviour {

	public GameObject BrickEmeraldParticle;

	void OnCollisionEnter (Collision col){
		Instantiate (BrickEmeraldParticle, transform.position, Quaternion.identity);
		GM.Instance.DestroyBrick ();
		Destroy (gameObject);
		//TODO add to score
	}
}
