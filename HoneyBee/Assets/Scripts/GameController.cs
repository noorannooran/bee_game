using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //access UI
using UnityEngine.SceneManagement; //access scene

public class GameController : MonoBehaviour {

	[SerializeField]
	GameObject enemyBee;
	[SerializeField]
	Button resetBtn; //button to reset on end-game screen


	// Use this for initialization
	void Start () {
		StartCoroutine("AddEnemy");

	}

	// Update is called once per frame
	void Update () {
		
	}
		
	private IEnumerator AddEnemy(){
		//adds enemy bees every X seconds
		int time = Random.Range(3,10); //random time
		yield return new WaitForSeconds ((float) time); //return 
		Instantiate(enemyBee); //create enemy bee
		StartCoroutine ("AddEnemy"); //start another coroutine
	}
}
