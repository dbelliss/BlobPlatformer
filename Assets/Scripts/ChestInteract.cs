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
    private EngagingSensor engSensor;
    private SpriteRenderer spRender;

	// Use this for initialization
	void Start () {
        animator = transform.parent.GetComponent<Animator>();
        follow = transform.parent.GetComponent<FollowAi>();
        engSensor = transform.parent.FindChild("EngagingRadius").GetComponent<EngagingSensor>();
        spRender = transform.parent.GetComponent<SpriteRenderer>();

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
            interactOpenMimic();
            spRender.sortingOrder = 1;
        }
    }

    void FixedUpdate()
    {
        if (follow.engageTimer <= reactionTime && isMimic)
        {
            animator.SetBool("OpenMimic", true);
            engSensor.setRadius(10.0f);
            spRender.sortingOrder = 1;
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

    public void interactOpenMimic()
    {
        follow.setTimer(reactionTime);
    }
}
