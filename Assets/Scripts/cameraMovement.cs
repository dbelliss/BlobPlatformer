using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	Vector3 displacement;
	public Transform player;
	private Transform camera;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Transform> ();
		displacement = camera.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		camera.position =  (displacement + player.position);
	}
}
