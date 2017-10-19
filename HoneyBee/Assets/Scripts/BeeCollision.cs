using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController; //reference to gamecontroller script

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("flower")) {
			//collision with flower
			Debug.Log ("Yummy!\n");
			//disappear flower -- reset
			other.gameObject.GetComponent<FlowerController>().Reset();
			//update score
			gameController.Score+=1;
		}
		else if (other.gameObject.tag.Equals ("enemy")) {
			//collision with enemy
			Debug.Log ("Ouch!\n");
			//disappear enemy -- reset
			other.gameObject.GetComponent<EnemyController>().Reset();
			//update lives
			gameController.Lives-=1;
		
		}



	}
}
