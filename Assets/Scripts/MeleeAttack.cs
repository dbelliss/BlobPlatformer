using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
    private Animator animator;
    private bool isActive;
    AnimatorStateInfo animState;
    PickUpItem pickUpItem;

    // Use this for initialization
    void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
            animState = animator.GetCurrentAnimatorStateInfo(1);

    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (isActive && coll.gameObject.tag == "Enemy" && animState.IsName("BlobAttack"))
        {
            Destroy(coll.gameObject);
        }

        else if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            pickUpItem.removeItem();
        }
    }

    public void setActive()
    {
        isActive = true;
    }

    public void setAnimator(Animator anim)
    {
        animator = anim;
    }

    public void setPickUpItem(PickUpItem pickItem)
    {
        pickUpItem = pickItem;
    }
}
