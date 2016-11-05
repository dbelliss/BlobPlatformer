using UnityEngine;
using System.Collections;

public class ChestInteract : MonoBehaviour {
    private bool interaction = false;
    private Animator animator;
    public bool isRegular;
    public bool isMimic;
    public bool isRandom;
    public float randomChanceMimic;

	// Use this for initialization
	void Start () {
        animator = transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float verticalDirection = Input.GetAxis("Vertical");
        if (verticalDirection > 0 && interaction && isRegular)
        {
            animator.SetBool("OpenRegular", true);
        }
        else if (verticalDirection > 0 && interaction && isMimic)
        {
            animator.SetBool("OpenMimic", true);
        }
        else if (verticalDirection > 0 && interaction && isRandom)
        {
            float randomNum = Random.Range(0.0f, 1.0f);
            if (randomNum < randomChanceMimic)
                animator.SetBool("OpenMimic", true);
            else
                animator.SetBool("OpenRegular", true);
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
}
