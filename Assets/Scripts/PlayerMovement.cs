using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    //For horizontal movement
    bool facingRight = true;

    //For Jumping
    float groundRadius = .1f;
    private bool grounded = false;
    private bool touchedGround = false;
    public Transform floorDetector;
    public LayerMask whatIsGround;

    //For endgame
    public static bool isDead = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(floorDetector.position, groundRadius, whatIsGround);
        animator.SetBool("grounded", grounded);


        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));

        if (facingRight && moveHorizontal < 0)
        {
            flip();
            facingRight = !facingRight;
        }
        else if (!facingRight && moveHorizontal > 0)
        {
            flip();
            facingRight = !facingRight;
        }

        if (moveHorizontal >= 0)
        {
            spriteRenderer.flipX = false;
        }

        // rb.AddForce (movement * speed);
        if (moveHorizontal < 0.1)
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        else if (moveHorizontal > 0.1)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }

        if (grounded && Input.GetButton("Jump") && touchedGround)
        {
            rb.AddForce(new Vector2(0, jumpHeight));
            touchedGround = false;
        }
    }

    void flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == 9)
        {
            touchedGround = true;
        }
    }
}