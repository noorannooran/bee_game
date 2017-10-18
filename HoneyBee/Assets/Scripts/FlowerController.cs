using UnityEngine;

public class FlowerController : MonoBehaviour {


	//Public variables

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startY = 251f;
	[SerializeField]
	private float endY = -157;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;


	//private variables

	private Transform _transform;

	private Vector2 _currentPos;



	// Use this for initialization
	void Start () {

		_transform = gameObject.GetComponent<Transform> ();

		_currentPos = _transform.position;
		Reset ();
	}



	// Update is called once per frame

	void Update () {

		_currentPos = _transform.position;

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




	private void Reset(){


		float y = Random.Range (startY, endY);

		_currentPos = new Vector2 (endX, y);
	}
}