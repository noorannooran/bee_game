using UnityEngine;

/* Nooran El-Sherif 100695733
 * FlowerController
 * Last Modified By: Nooran El-Sherif 
 * Date Last Modified: October 20, 2017
 * Description: Controls the behaviour of Flower prefab
 * 
 * Revision History:
 * October 18, 2017:
 * FlowerController class created
 * - serialized fields added for speed, start X&Y end X&Y
 * - reset added - move enemy bee to beginning, randomize speed
 * - update updates the position of the bee using the speed
 * - reset randomizes where on the Y axis the flower appears
 * -------------------
 * October 19, 2017:
 * - deleted unnecessary whitespace
 * -------------------
 * October 20, 2017
 * Header Added
 * Some comments added
 */

public class FlowerController : MonoBehaviour {


	//Public variables
	[SerializeField]
	private float speed = 5f; //speed of flower
	[SerializeField]
	private float startY = 251f; //starting Y position
	[SerializeField]
	private float endY = -157; //ending Y position
	[SerializeField]
	private float startX; //starting X position
	[SerializeField]
	private float endX; //ending X position


	//private variables
	private Transform _transform;
	private Vector2 _currentPos;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> (); //get transform
		_currentPos = _transform.position; //set current position
		Reset (); //reset
	}



	// Updates the current position, checks if within boundary
	void Update () {
		_currentPos = _transform.position; //set current position

		//move flower to the left
		_currentPos -= new Vector2 (speed,0);

		//check if we need to reset
		if (_currentPos.x < startX) {
			//reset
			Reset ();
		}

		//apply changes
		_transform.position = _currentPos;

	}

	//reset position of flower to right of screen
	public void Reset(){
		
		float y = Random.Range (startY, endY); //randomize where flower appears on y axis

		_currentPos = new Vector2 (endX + Random.Range(100,500), y); //set current position
		_transform.position = _currentPos; //apply changes
	}
}