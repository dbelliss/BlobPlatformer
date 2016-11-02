using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour {
	public Transform shootPoint; //Where to shoot from
	public GameObject Arrow; //Projectile
	public bool alwaysShoot = false;
	public float range = 20.0f; //range of detection
	public float fireRate = 1.0f; //arrows per second
	public float arrowSpeed = .1f; //Speed of arrow to shoot
	bool isShooting = false; //To know when to start coroutine

	// Use this for initialization
	void Start () {
		StartCoroutine (ShootArrow ());
	}

	// Update is called once per frame
	void Update () {
		
	}
		


	void FixedUpdate() {
		if (alwaysShoot == true) {
			return;
		}//If always shooting, just return

		float angle = transform.rotation.eulerAngles.z/ 180 * Mathf.PI;
		RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle),  0), range, 1 << 8); //raycast to the left
		Debug.DrawRay(shootPoint.position, new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle),  0) * range, Color.green);// show ray in scene view
		if (hit) {
			isShooting = true;
		}//if raycast hits player, begin shooting if not already shooting
		else {
			isShooting = false;
		}//stop shooting if player out of range
	}



	/*
	 * 
	 * 
	 * */
	IEnumerator ShootArrow() {
		while (true) {
			//shoot arrow
			if (isShooting || alwaysShoot) {
				GameObject go = Instantiate (Arrow, shootPoint.position, Quaternion.identity) as GameObject;
				ArrowMovement arr = go.GetComponent<ArrowMovement> ();
				arr.speed = arrowSpeed; //speed to shoot arrows
				arr.angle = transform.rotation.eulerAngles.z; //angle to shoot arrows in degrees
			}
			yield return new WaitForSeconds (1/fireRate);
		}
	}//shoot arrow every second if player is in range

}
