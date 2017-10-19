using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	//singleton class to store player info

	//store reference
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
	private GameController gCtrl;
	private int _score = 0;
	private int _lives = 3;
	private int _highScore = 0;

	//public getters and setters
	public GameController GCtrl{
			get{ return gCtrl; }
			set{ gCtrl = value; }
		}
	public int Score {
			get{ return _score; }
			set {
				_score = value;
				//update UI

				gCtrl.updateUI();
			}
		}
	public int Lives{
			get{ return _lives; }
			set{_lives = value;
				//check if game over
				if (_lives <= 0) {
					//game over
				if (_score > _highScore)
					_highScore = _score;
					gCtrl.gameOver(_highScore);
				} else {
					//update UI

					gCtrl.updateUI();
				}
			}
		}
	public int HighScore{
		get{ return _highScore; }
		//set{ _highScore = value; }
	}




}
