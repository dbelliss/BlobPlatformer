using UnityEngine;
using System.Collections;

public class ZombieAi : MonoBehaviour {
    public Transform target = null;
    public float moveSpeed;

    // Use this for initialization
    void Start () {

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
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        target = other.transform;
    //    }
    //}

    void flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
