using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	public float torque;
	public Rigidbody rb;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		rb.AddTorque(transform.forward * torque);
	}
	
	// Update is called once per frame
	void Update () {
		
	}




}
