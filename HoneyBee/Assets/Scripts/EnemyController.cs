using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private float minXSpeed = 7f;
	[SerializeField]
	private float maxXSpeed = 10f;
	[SerializeField]
	private float minYSpeed = -2f;
	[SerializeField]
	private float maxYSpeed = 1f;

	//enemy boundaries
	[SerializeField]
	private float leftX = -600f;

	//private fields
	private Transform _transform;
	private Vector2 _currentSpeed; //current speed of enemy bee
	private Vector2 _currentPosition; //current position of enemy bee

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}
	public void Reset(){
		//move enemy bee to the beginning
		//randomize the speed of the enemy

		float xSpeed = Random.Range (minXSpeed, maxXSpeed); //randomize xspeed
		float ySpeed = Random.Range (minYSpeed, maxYSpeed); //randomize yspeed

		_currentSpeed = new Vector2 (xSpeed, ySpeed); //set current speed to random speed

		float y = Random.Range (-158, 222); //y position bee appears
		_transform.position = new Vector2(574 + Random.Range(0, 100), y); //apply changes



	}
	// Update is called once per frame
	void Update () {
		_currentPosition = _transform.position; //current position
		_currentPosition -= _currentSpeed; //move bee left at current speed

		_transform.position = _currentPosition; //apply changes
		if (_currentPosition.x <= leftX) {
			Reset ();
		}

	}

}
