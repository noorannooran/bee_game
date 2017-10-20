using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Nooran El-Sherif 100695733
 * EnemyController
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Controls the behaviour of Enemy Bee prefab
 * 
 * Revision History:
 * October 19, 2017:
 * EnemyController class created
 * - serialized fields added for Xspeed/ yspeed
 * - reset added - move enemy bee to beginning, randomize speed
 * - update updates the position of the bee using the speed
 * -------------------
 * October 20, 2017:
 * Header Added
 * Some comments added
 */

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private float minXSpeed = 7f; //minimum Xspeed
	[SerializeField]
	private float maxXSpeed = 10f; //maximum Xspeed
	[SerializeField]
	private float minYSpeed = -2f; //minimum YSpeed
	[SerializeField]
	private float maxYSpeed = 1f; //maximum Yspeed

	//enemy boundaries
	[SerializeField]
	private float leftX = -600f; //left boundary

	//private variables
	private Transform _transform;
	private Vector2 _currentSpeed; //current speed of enemy bee
	private Vector2 _currentPosition; //current position of enemy bee

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	//move enemy bee to the beginning
	//randomize the speed of the enemy
	public void Reset(){

		float xSpeed = Random.Range (minXSpeed, maxXSpeed); //randomize xspeed
		float ySpeed = Random.Range (minYSpeed, maxYSpeed); //randomize yspeed

		_currentSpeed = new Vector2 (xSpeed, ySpeed); //set current speed to random speed

		float y = Random.Range (-158, 222); //y position bee appears
		_transform.position = new Vector2(574 + Random.Range(0, 100), y); //apply changes



	}
	// Updates the enemy's position in the frame
	void Update () {
		_currentPosition = _transform.position; //current position
		_currentPosition -= _currentSpeed; //move bee left at current speed

		_transform.position = _currentPosition; //apply changes
		if (_currentPosition.x <= leftX) {
			Reset ();
		}

	}

}
