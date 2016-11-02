using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {
	public float speed = -1;
	bool moving = true; //If hasn't hit something
	BoxCollider2D boxcollider;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5.0f);
		boxcollider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (moving) {
			transform.position = (transform.position + new Vector3 (.1f * speed, 0.0f, 0.0f));
		}//If hasn't hit something
	}

	void OnCollisionEnter2D(Collision2D collision) {
		// Debug-draw all contact points and normals
		print ("test");
		Debug.Log ("testtt");
		foreach (ContactPoint2D contact in collision.contacts) {
			Debug.DrawRay (contact.point, contact.normal, Color.white);
		}
		boxcollider.enabled = false;
		moving = false;
		gameObject.transform.parent = collision.gameObject.transform;
	}


}
