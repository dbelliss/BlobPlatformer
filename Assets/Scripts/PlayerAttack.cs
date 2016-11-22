using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    private Animator animator;
    private AnimatorStateInfo animState;
    public float criticalChance;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animState = animator.GetCurrentAnimatorStateInfo(1);

        if (Input.GetButtonDown("Attack"))
        {
            float randomNum = Random.Range(0.0f, 1.0f);
            if (randomNum > criticalChance)
                animator.SetBool("slash", true);
            else
                animator.SetBool("stab", true);
        }
        else
        {
            animator.SetBool("slash", false);
            animator.SetBool("stab", false);
        }
	}
}
