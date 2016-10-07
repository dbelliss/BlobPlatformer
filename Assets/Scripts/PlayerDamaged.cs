using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerDamaged : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject == null) {
			print ("dead");
		}


	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Spikes") {
			Destroy (gameObject);
			PlayerMovement.isDead = true;
		}
		if (coll.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			PlayerMovement.isDead = true;
		}
	}
}
