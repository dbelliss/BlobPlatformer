using UnityEngine;
using System.Collections;

public class EngagingSensor : MonoBehaviour {
    private FollowAi follow;
    private CircleCollider2D circleCol;

	// Use this for initialization
	void Start () {
        follow = transform.parent.gameObject.GetComponent<FollowAi>();
        circleCol = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            follow.setTarget(other.transform);
        }
    }

    public void setRadius(float newRadius)
    {
        circleCol.radius = newRadius;
    }
}
