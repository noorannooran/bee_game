using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //access UI
using UnityEngine.SceneManagement; //access scene

/* Nooran El-Sherif 100695733
 * UIManager
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Controls the game UI elements
 * 
 * Revision History:
 * October 20, 2017
 * - UIManager added
 * - UI control migrated from gamecontroller
 * - in Start() set Player.Instance.Ui = this
 * -----------------------
 * Header Added
 * Comments added for methods
 */

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
	//resets all labels at game start
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
	//sets game over labels to appear at game over
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
	//updates the UI with new score and new lives
	public void updateUI()
	{
		if (scoreLabel != null && livesLabel != null) {
			//update score label with player score
			scoreLabel.text = "Nectar: " + Player.Instance.Score + " mL";
			//update lives label with player lives
			livesLabel.text = "Stingers: " + Player.Instance.Lives;
		}
	}
	//reload scene when button is clicked
	public void ResetBtnClick(){
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
