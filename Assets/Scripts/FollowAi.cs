using UnityEngine;
using System.Collections;

public class FollowAi : MonoBehaviour {
    private Transform target = null;
    public float moveSpeed;
    private Animator animator;
    private bool moving = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetDirection = target.position - transform.position;
            float flipValue = transform.localScale.x;

            if (targetDirection.x < 0)
            {
                if (flipValue < 0)
                    flip();
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                if (flipValue > 0)
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
}
