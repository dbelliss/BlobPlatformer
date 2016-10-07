using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform tf;
	public float speed;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		Vector3 movement = new Vector3 (tf.position.x + speed, tf.position.y, tf.position.z);
		tf.position =  movement;
	}
}
