using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController; //reference to gamecontroller script
	[SerializeField]
	GameObject droplet; //access droplet animation
	[SerializeField]
	AudioSource _flowerSound;
	[SerializeField]
	AudioSource _enemySound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
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
	private IEnumerator Blink(){
		//makes the bee "blink"/ become transparent
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
