using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	private Animator animator; 
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);


		if (moveHorizontal == 0) {
			animator.ResetTrigger ("isMoving");
			print ("1");
		} else {
			animator.SetTrigger ("isMoving");
			print ("2");
			if (moveHorizontal < 0) {
				spriteRenderer.flipX = true;
				print ("3");
			}
		}

		if (moveHorizontal >= 0) {
			spriteRenderer.flipX = false;
		}
	

		rb.velocity = (movement * speed);
	}
}
