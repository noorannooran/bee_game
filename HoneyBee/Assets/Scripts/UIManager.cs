using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //access UI
using UnityEngine.SceneManagement; //access scene

public class UIManager : MonoBehaviour {

	[SerializeField]
	Text livesLabel; //label to display number of lives on game screen
	[SerializeField] 
	Text scoreLabel; //label to display score on game screen
	[SerializeField]
	Text gameOverLabel; //label to display game over on end-game screen
	[SerializeField]
	Button resetBtn; //button to reset on end-game screen


	//function to initalize UI
	private void initialize(){
		//reset values
		Player.Instance.Score = 0;
		Player.Instance.Lives = 3;
		//display start UI elements
		gameStart();
	}
	public void gameStart()
	{
		//disable game over label
		gameOverLabel.gameObject.SetActive(false);
		//disable reset button
		resetBtn.gameObject.SetActive(false);

		//enable life label
		livesLabel.gameObject.SetActive(true);
		//enable score label
		scoreLabel.gameObject.SetActive(true);
	}
	public void gameOver()
	{
		//enable game over label
		gameOverLabel.gameObject.SetActive (true);
		//enable reset button
		resetBtn.gameObject.SetActive(true);

		//disable lives label
		livesLabel.gameObject.SetActive(false);
		//disable score label
		scoreLabel.gameObject.SetActive(false);
	}
	public void updateUI()
	{
		if (scoreLabel != null && livesLabel != null) {
			//update score label with player score
			scoreLabel.text = "Nectar: " + Player.Instance.Score + " mL";
			//update lives label with player lives
			livesLabel.text = "Stingers: " + Player.Instance.Lives;
		}
	}
	public void ResetBtnClick(){
		//reload scene when button is clicked
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	// Use this for initialization
	void Start () {
		Player.Instance.Ui = this; //connect to player UIManager
		initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
