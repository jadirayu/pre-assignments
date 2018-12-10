using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	public GameObject BrickParticle;

	void OnCollisionEnter (Collision other){
		Instantiate (BrickParticle, transform.position, Quaternion.identity);
		GM.Instance.DestroyBrick();
		Destroy (gameObject);
	}
}
