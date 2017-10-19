using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //access UI
using UnityEngine.SceneManagement; //access scene

public class GameController : MonoBehaviour {

	[SerializeField]
	Text livesLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameOverLabel;
	[SerializeField]
	Text highScoreLabel;
	[SerializeField]
	Button resetBtn;

	//private variables
	private int _score = 0;
	private int _lives = 3;

	//public getters and setters
	public int Score {
		get{ return _score; }
		set {
			_score = value;
			//update UI
			scoreLabel.text = "Nectar: " + _score + " mL";
		}
	}
	public int Lives{
		get{ return _lives; }
		set{_lives = value;
			//check if game over
			if (_lives <= 0) {
				//game over
				gameOver();
			} else {
				//update UI
				livesLabel.text = "Stingers: " + _lives;
			}
		}
	}
	//function to initalize UI
	private void initialize(){
	//disappear labels, reset values
		Score = 0;
		Lives = 3;

		//disable game over label
		gameOverLabel.gameObject.SetActive (false);
		//disable high score label
		highScoreLabel.gameObject.SetActive(false);
		//disable reset button
		resetBtn.gameObject.SetActive(false);

		//enable life label
		livesLabel.gameObject.SetActive(true);
		//enable score label
		scoreLabel.gameObject.SetActive(true);
	
	}
	private void gameOver(){
		//enable game over label
		gameOverLabel.gameObject.SetActive (true);
		//enable high score label
		highScoreLabel.gameObject.SetActive(true);
		//enable reset button
		resetBtn.gameObject.SetActive(true);

		//disable lives label
		livesLabel.gameObject.SetActive(false);
		//disable score label
		scoreLabel.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetBtnClick(){
		//reload scene when button is clicked
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
