using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {
    //public Transform target;
    private Transform weaponHand;
    private bool interaction;

	// Use this for initialization
	void Start () {
        weaponHand = transform.FindChild("WeaponHand");
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Item") && Input.GetButtonDown("Interact"))
        {
            Destroy(coll.gameObject.GetComponent<Rigidbody2D>());
            coll.transform.parent = weaponHand;
            coll.transform.localPosition = new Vector3(0, 0, 0);
            coll.transform.localRotation = Quaternion.Euler(0, 0, -30);
        }
    }

    void equipWeapon(Transform target)
    {
        weaponHand.position = target.position;
    }
}
