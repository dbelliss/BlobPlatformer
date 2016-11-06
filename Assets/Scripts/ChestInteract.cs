using UnityEngine;
using System.Collections;

public class ChestInteract : MonoBehaviour {
    private bool interaction = false;
    private Animator animator;
    public bool isMimic;
    public bool isRandom;
    public float randomChanceMimic;
    public float reactionTime;
    private FollowAi follow;

	// Use this for initialization
	void Start () {
        animator = transform.parent.GetComponent<Animator>();
        follow = transform.parent.GetComponent<FollowAi>();

        if (isRandom)
        {
            float randomNum = Random.Range(0.0f, 1.0f);
            if (randomNum < randomChanceMimic)
            {
                isMimic = true;
                follow.setActive(true);
            }
            else
            {
                isMimic = false;
                follow.setActive(false);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        float verticalDirection = Input.GetAxis("Vertical");
        if (verticalDirection > 0 && interaction && !isMimic)
        {
            animator.SetBool("OpenRegular", true);
        }
        else if (verticalDirection > 0 && interaction && isMimic)
        {
            animator.SetBool("OpenMimic", true);
            surpriseOpenMimic();
        }
    }

    void FixedUpdate()
    {
        if (follow.engageTimer <= reactionTime && isMimic)
        {
            animator.SetBool("OpenMimic", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interaction = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            interaction = false;
    }

    public void surpriseOpenMimic()
    {
        follow.setTimer(reactionTime);
    }
}
