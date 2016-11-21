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
			Destroy (transform.parent.gameObject);
			PlayerMovement.isDead = true;
		}
		if (coll.gameObject.tag == "Enemy") {
			Destroy (transform.parent.gameObject);
			PlayerMovement.isDead = true;
		}

	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Arrow") {
			Destroy (transform.parent.gameObject);
			PlayerMovement.isDead = true;
		}//If player is hit by arrow
	}
}
