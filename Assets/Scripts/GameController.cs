using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {


	public Text scoreText1;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		resetScore ();
	}

	public void incrementScore (int bonus) {
		score += bonus;
		changeScore ();
	}//Increments score by bonus and calls function to change text

	void resetScore() {
		score = 0;
		changeScore ();
	}//Resets score to 0 and calls function to chagne text

	void  changeScore () {
		scoreText1.text = "Score: " + score;
	}//Change text to current Score
}
