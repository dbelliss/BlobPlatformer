﻿using UnityEngine;
using System.Collections;

public class TrackingSensor : MonoBehaviour {
    private FollowAi follow;

    // Use this for initialization
    void Start () {
        follow = transform.parent.gameObject.GetComponent<FollowAi>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            follow.unsetTarget();
        }
    }
}
