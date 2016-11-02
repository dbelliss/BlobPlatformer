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
		transform.eulerAngles= new Vector3 (0,0,(angle)); //rotate arrow sprite by this many degrees
		angle = angle / 180 * Mathf.PI;//convert to radians
		direction = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle),  0);//direction to shoot as a unit vector
	//	print (direction);
		Destroy (gameObject, 5.0f); //how long each arrow lasts
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
