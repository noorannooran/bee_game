using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Nooran El-Sherif 100695733
 * Sky Controller
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Controls the movement of the Background
 * 
 * Revision History:
 * October 18, 2017:
 * Sky controller added
 * - methods Start() Update() and Reset() added
 * -----------------
 * October 20, 2017:
 * Header Added
 */

public class SkyController : MonoBehaviour {
	//controls the movement of the sky background

	[SerializeField] //can access through Unity
	private float speed = 5f; //speed of sky movement
	[SerializeField]
	private float startX = 130f; //beginning of background
	[SerializeField] 
	private float endX = -170f; //end of background

	//private variables (not accessible through Unity)
	private Transform _transform; //keep track of position, rotation, scale
	private Vector2 _currentPos; //keep track of current position

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position; //get current position
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position; //get current position
		_currentPos -= new Vector2(speed, 0); //move sky left

		//check if the sky has ended
		if (_currentPos.x < endX) {
			Reset ();
		}

		_transform.position = _currentPos; //apply transformation to sky


	}
	private void Reset(){
		//resets the sky
		_currentPos = new Vector2(startX, 0);

	}
}
