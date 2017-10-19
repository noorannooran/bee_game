using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //access UI
using UnityEngine.SceneManagement; //access scene

public class GameController : MonoBehaviour {

	[SerializeField]
	GameObject enemyBee;
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


	//function to initalize UI
	private void initialize(){
	//disappear labels, reset values
		Player.Instance.Score = 0;
		Player.Instance.Lives = 3;

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

		//add enemy
		StartCoroutine("AddEnemy");
	
	}
	public void gameOver(int score){
		//enable game over label
		gameOverLabel.gameObject.SetActive (true);
		//enable high score label
		highScoreLabel.gameObject.SetActive(true);
		highScoreLabel.text = "High Score: " + Player.Instance.HighScore;
		//enable reset button
		resetBtn.gameObject.SetActive(true);

		//disable lives label
		livesLabel.gameObject.SetActive(false);
		//disable score label
		scoreLabel.gameObject.SetActive(false);
	}
	public void updateUI(){
		scoreLabel.text = "Nectar: " + Player.Instance.Score + " mL";
		livesLabel.text = "Stingers: " + Player.Instance.Lives;
	}

	// Use this for initialization
	void Start () {
		Player.Instance.GCtrl = this; //connect to player gCtrl
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetBtnClick(){
		//reload scene when button is clicked
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	private IEnumerator AddEnemy(){
		//adds enemy bees every X seconds
		int time = Random.Range(3,10); //random time
		yield return new WaitForSeconds ((float) time); //return 
		Instantiate(enemyBee); //create enemy bee
		StartCoroutine ("AddEnemy"); //start another coroutine
	}
}
