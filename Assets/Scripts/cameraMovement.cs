using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	Vector3 displacement;
	public Transform player;
	private Transform mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Transform> ();
		displacement = mainCamera.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
        if (player)
        {
            mainCamera.position = (displacement + player.position);
        }
	}
}
