using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;
	private Animator animator; 
	private SpriteRenderer spriteRenderer;

	//For horizontal movement
	bool facingRight = true;

	//For Jumping
	float groundRadius = .2f;
	private bool grounded = false;
	public Transform floorDetector;
	public LayerMask whatIsGround;

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
		grounded = Physics2D.OverlapCircle (floorDetector.position, groundRadius, whatIsGround);
		animator.SetBool ("grounded", grounded);
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		animator.SetFloat ("speed", Mathf.Abs (moveHorizontal));

		if (facingRight && moveHorizontal < 0) {
			flip ();
			facingRight = !facingRight;
		}
		else if (!facingRight && moveHorizontal > 0) {
			flip();
			facingRight = !facingRight;
		}

		if (moveHorizontal >= 0) {
			spriteRenderer.flipX = false;
		}
	

		rb.velocity = (movement * speed);
	}

	void flip() {
		Vector3 temp = transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;
	}
}
