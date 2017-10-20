using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Nooran El-Sherif 100695733
 * Bee Controller
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Controls the movement of the Player's Bee
 * 
 * Revision History:
 * October 18, 2017:
 * Bee controller added
 * - methods Start() Update() and CheckBounds() added
 * --------------------
 * October 20, 2017:
 * Header Added
 * Some comments added
 */

public class BeeController : MonoBehaviour {

	[SerializeField] //accessible through unity
	private float speed = 7f; //speed of the bee

	//boundaries for bee
	[SerializeField]
	private float leftX; //left boundary
	[SerializeField]
	private float rightX; //right boundary
	[SerializeField]
	private float topY;  //top boundary
	[SerializeField]
	private float bottomY; //bottom boundary

	//private variables
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Updates position of the player bee
	void Update () {
		_currentPos = _transform.position; //get current position

		//move up if W key pressed
		if (Input.GetKey (KeyCode.W)) {
			_currentPos += new Vector2 (0, speed);
		}
		//move down if S key pressed
		if (Input.GetKey (KeyCode.S)) {
			_currentPos -= new Vector2 (0, speed);
		}
		//move left if A key pressed
		if (Input.GetKey (KeyCode.A)) {
			_currentPos -= new Vector2 (speed, 0);
		}
		//move right if D key pressed
		if (Input.GetKey (KeyCode.D)) {
			_currentPos += new Vector2 (speed, 0);
		}

		CheckBounds (); //check if changes are within boundaries
		//update position
		_transform.position = _currentPos;
	}
	//checks if the gameObject is within the boundaries of the frame
	private void CheckBounds(){
		//left boundary
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		//right boundary
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
		//top boundary
		if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		//bottom boundary
		if (_currentPos.y < bottomY) {
			_currentPos.y = bottomY;
		}

	}
}
