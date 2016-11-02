using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {
	public float speed = -1;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (transform.position + new Vector3 (.1f * speed, 0.0f, 0.0f));
	}
}
