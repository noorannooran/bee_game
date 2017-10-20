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
	private UIManager ui;
	private int _score = 0;
	private int _lives = 3;

	//public getters and setters
	public UIManager Ui{
			get{ return ui; }
			set{ ui = value; }
		}
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
	







