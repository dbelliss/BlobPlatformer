using UnityEngine;
using System.Collections;

public class TrackingSensor : MonoBehaviour {
    private ZombieAi zombie;

    // Use this for initialization
    void Start () {
        zombie = transform.parent.gameObject.GetComponent<ZombieAi>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            zombie.target = null;
        }
    }
}
