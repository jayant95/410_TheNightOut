using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public float intoxicationLevel;
	public bool itemHeld = false;
	private GameObject pickup;

	// Use this for initialization
	void Start () {
		moveSpeed = 3.0f;
		intoxicationLevel = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		movePlayer ();
		drainIntoxication (0.05f);

	}


	void drunkMovement() {

		float factor = (100 - intoxicationLevel) / 100;
		moveSpeed = moveSpeed * factor;
		Debug.Log (moveSpeed);

	}

	void movePlayer() {

		//drunkMovement ();

		if (Input.GetKey (KeyCode.LeftArrow)) {
			//drunkMovement ();
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//drunkMovement ();
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			//drunkMovement ();
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			//drunkMovement ();
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}
	}

	void drainIntoxication(float factor) {
		if (intoxicationLevel > 0) {
			intoxicationLevel = intoxicationLevel - (1 * factor);
			//Debug.Log ("Intoxication Level: " + intoxicationLevel);
		} else {
			intoxicationLevel = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Alcohol") {
			Destroy (other.gameObject);
			intoxicationLevel += 20;
		}

		if (other.name == "Coffee") {
			if (intoxicationLevel >= 20) {
				intoxicationLevel -= 20;
				Destroy (other.gameObject);
			} else if (intoxicationLevel > 0 && intoxicationLevel < 20) {
				intoxicationLevel = 0;
				Destroy (other.gameObject);
			} else {
				// if intoxication is already 0 then don't destroy the object
				// tell the user that they are already have 0 intoxication
				Debug.Log("Intoxication level is already 0!");
			}
		}
			
	}
	
}
