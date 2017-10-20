using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //access UI
using UnityEngine.SceneManagement; //access scene

/* Nooran El-Sherif 100695733
 * Game Controller
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Instantiates enemies in the canvas
 * 
 * Revision History:
 * October 19, 2017:
 * - Game Controller added
 * - Serialized labels added to Game Controller
 * - get score and lives
 * - initialize: disppears labels, resets values to begin game state
 * - game over- opposite of initialize
 * - start calls initialize
 * - reset button click handler
 * -------------------------
 * - removed getter and setter for score and lives
 * - reference Player.Instance.Score .Lives instead
 * - passed score to gameOver() function to display in end label
 * - in start set Player.Instance.GCtrl = this
 * ------------------------
 * October 20, 2017:
 * - labels removed from GameController
 * - all UI removed from GameController including button handler
 * -------------------------
 * Header Added
 * Some comments added
 * Time range changed in AddEnemy
 */

public class GameController : MonoBehaviour {

	[SerializeField]
	GameObject enemyBee; //reference to enemyBee prefab
	[SerializeField]
	Button resetBtn; //button to reset on end-game screen


	// Use this for initialization
	void Start () {
		StartCoroutine("AddEnemy");

	}

	// Update is called once per frame
	void Update () {
		
	}

	//adds enemy bees every X seconds
	private IEnumerator AddEnemy(){
		int time = Random.Range(4,10); //random time
		yield return new WaitForSeconds ((float) time); //return 
		Instantiate(enemyBee); //create enemy bee
		StartCoroutine ("AddEnemy"); //start another coroutine
	}
}
