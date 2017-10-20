using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Nooran El-Sherif 100695733
 * Player
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Singleton Class to Store player Info
 * 
 * Revision History:
 * October 19, 2017:
 * - Player Added
 * - private variables added: Score, Lives, highscore, gCtrl
 * - public getters and setters
 * - setter for lives checks if lives > 0 , else gameOver
 * ------------------------
 * October 20, 2017
 * - replaced references to gCtrl to UIManager ui
 * - added playerprefs to store high score
 * ------------------------
 * - removed high score variables (couldn't get playerprefs to work)
 * ------------------------
 * Header Added
 * Some comments added
 */

public class Player {
	//singleton class to store player info

	//store reference to static instance
	static private Player _instance;

	//getter
	static public Player Instance {
		get {
			if (_instance == null) { //instantiate if doesn't exist
				_instance = new Player (); 
			}
			return _instance;
		}
	}
	//empty, private constructor
	private Player(){ }
	
	//private variables
	private UIManager ui;
	private int _score = 0;
	private int _lives = 3;

	//public getters and setters
	public UIManager Ui{
			get{ return ui; }
			set{ ui = value; }
		}
	//getter and setter for score
	public int Score {
			get{ return _score; }
			set {
			if (_lives >= 0) {
				_score = value;
				//update UI
				ui.updateUI ();
			}
			}
		}
	//getter and setter for lives
	public int Lives{
			get{ return _lives; }
			set{_lives = value;
				//check if game over
				if (_lives <= 0) {
				//game over   
				ui.gameOver();
			} else {
					//update UI
					ui.updateUI();
				}
			}
		}

	}
	







