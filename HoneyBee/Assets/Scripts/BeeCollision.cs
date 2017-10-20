using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Nooran El-Sherif 100695733
 * BeeCollision
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Controls What happens on Player Collisions
 *
 *Revision History:
 * October 19, 2017:
 * Bee Collision added
 * - on collision with flower : log says yummy
 * -----------------------------------------
 * - Reference to Game Controller added
 * - update score on collision with flower
 * - on collision with enemy: log says ouch
 * - update lives on collision with enemy
 * -----------------------------------------
 * - instantiate droplet animation on collision with flower
 * - added co-routine to "blink" on collision with enemy bee
 * ---------------------------------
 * October 20, 2017:
 * - test if player lives > 0 in order for collision to add points
 * - added audio for flower sound and enemy sound
 * --------------------
 * Header Added
 * Some comments added
 */

public class BeeCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController; //reference to gamecontroller script
	[SerializeField]
	GameObject droplet; //access droplet animation
	[SerializeField]
	AudioSource _flowerSound; //slurp audio file for when flower is collided
	[SerializeField]
	AudioSource _enemySound; //buzz enemy sound for when enemy is collided

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//controls what happens on collisions with flower and enemy
	public void OnTriggerEnter2D(Collider2D other){
		if (Player.Instance.Lives > 0) {
			if (other.gameObject.tag.Equals ("flower")) {
				//collision with flower
				Debug.Log ("Yummy!\n");
				if (_flowerSound != null)
					_flowerSound.Play ();
				//instantiate droplet animation
				Instantiate (droplet).GetComponent<Transform> ().position 
				= other.gameObject.GetComponent<Transform> ().position; //put animation in same position as flower
				//disappear flower -- reset
				other.gameObject.GetComponent<FlowerController> ().Reset ();
				//update score
				Player.Instance.Score += 1;
			} else if (other.gameObject.tag.Equals ("enemy")) {
				//collision with enemy
				Debug.Log ("Ouch!\n");
				if (_enemySound != null)
					_enemySound.Play ();
				//disappear enemy -- reset
				other.gameObject.GetComponent<EnemyController> ().Reset ();
				//update lives
				Player.Instance.Lives -= 1;

				//start coroutine to change transparency of bee
				StartCoroutine ("Blink");
		
			}
		}



	}
	//makes the bee become transparent and then opaque
	private IEnumerator Blink(){
		Color c;
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		//repeat two times
		for (int i = 0; i < 3; i++) {
			
			for (float f = 1f; f >= 0; f -= 0.1f) {
				//from opaque -> transparent
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.05f); //first loop ->exit -> back to loop
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				//from transparent _> opaque
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.05f); //first loop ->exit -> back to loop
			}
		}
	}
}
