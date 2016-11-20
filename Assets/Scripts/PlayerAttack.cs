using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
	}
}
