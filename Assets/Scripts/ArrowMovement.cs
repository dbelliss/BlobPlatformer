using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {
	public float speed = .01f;
	public float angle = Mathf.PI; //default to the left
	Vector3 direction = Vector3.left;
	bool moving = true; //If hasn't hit something
	BoxCollider2D boxcollider;
	// Use this for initialization
	void Start () {
		transform.eulerAngles= new Vector3 (0,0,(angle));
		angle = angle / 180 * Mathf.PI;
		direction = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle),  0);
	//	print (direction);

		Destroy (gameObject, 5.0f);

		boxcollider = GetComponent<BoxCollider2D> ();

	}

	// Update is called once per frame
	void LateUpdate () {
		if (moving) {
			transform.position = (transform.position + direction * speed);
		}//If hasn't hit something
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Arrow") {
			return;
		}
		// Debug-draw all contact points and normals
		boxcollider.enabled = false; //Can no longer kill player 
		moving = false; //stop moving
		gameObject.transform.parent = collision.gameObject.transform; //stick to whatever it hits
	}


}
