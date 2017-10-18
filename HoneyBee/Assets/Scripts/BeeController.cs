using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

	[SerializeField] //accessible through unity
	private float speed = 7f; //speed of the bee

	//boundaries for bee
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;

	//private fields
	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Update is called once per frame
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
	private void CheckBounds(){
		//check if the position of the bee is out of bounds
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
		if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		if (_currentPos.y < bottomY) {
			_currentPos.y = bottomY;
		}

	}
}
