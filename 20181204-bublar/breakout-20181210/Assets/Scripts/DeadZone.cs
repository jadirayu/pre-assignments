using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		GM.Instance.LoseLife ();	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
