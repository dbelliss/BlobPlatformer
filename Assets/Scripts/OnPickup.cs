using UnityEngine;
using System.Collections;

public class OnPickup : MonoBehaviour {

	private GameController gameController;
	public Collider2D player;
	private Collider2D col;
	public int scoreValue;
	// Use this for initialization
	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (col.IsTouching (player)) {
			//print ("touching");
			Destroy (gameObject);
		}

	}
}
