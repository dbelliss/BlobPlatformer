using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour {
	public Transform shootPoint; //Where to shoot from
	public GameObject Arrow; //Projectile
	public bool alwaysShoot = false;
	public float range = 20.0f; //range of detection
	public float fireRate = 1.0f; //arrows per second
	public float arrowSpeed = -1f; //Speed of arrow to shoot
	public float arrowDirection = 0f;

	bool isShooting = false;
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

		RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, Vector2.left, range, 1 << 8); //raycast to the left
		Debug.DrawRay(shootPoint.position, Vector2.left * range, Color.green);// show ray in scene view
		if (hit) {
				isShooting = true;
		}//if raycast hits player, begin shooting if not already shooting
		else {
			isShooting = false;
		}
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
				Debug.Log (arr);
				arr.speed = arrowSpeed; //speed to shoot arrows
				arr.angle = arrowDirection; //angle to shoot arrows
			}
			yield return new WaitForSeconds (1/fireRate);
		}
	}//shoot arrow every second if player is in range

}
