using UnityEngine;
using System.Collections;

public class FollowAi : MonoBehaviour {
    private Transform target = null;
    public float moveSpeed;
    private Animator animator;
    private bool moving = false;
    public float engageTimer;
    private bool isActive = true;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        if (target && engageTimer <= 0.0f && isActive)
        {
            Vector3 targetDirection = target.position - transform.position;
            float flipValue = transform.localScale.x;

            gameObject.tag = "Enemy";
            gameObject.layer = 8;

            if (targetDirection.x < 0.0f)
            {
                if (flipValue < 0.0f)
                    flip();
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                if (flipValue > 0.0f)
                    flip();
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            moving = true;
        }
        else
        {
            moving = false;
        }
        animator.SetBool("isMoving", moving);

        if (target && engageTimer > 0.0f)
        {
            engageTimer -= Time.deltaTime;
        }
    }

    void flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    public void unsetTarget()
    {
        target = null;
    }

    public void setTimer(float timeValue)
    {
        engageTimer = timeValue;
    }

    public void setActive(bool activeState)
    {
        isActive = activeState;
    }
}
