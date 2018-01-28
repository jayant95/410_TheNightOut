using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	private float intoxicationLevel;

	// Use this for initialization
	void Start () {
		moveSpeed = 3.0f;
		intoxicationLevel = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}
			
		drainIntoxication (0.01f);
	}

	void drainIntoxication(float factor) {
		if (intoxicationLevel > 0) {
			intoxicationLevel = intoxicationLevel - (1 * factor);
			Debug.Log ("Intoxication Level: " + intoxicationLevel);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Alcohol") {
			Destroy (other.gameObject);
			intoxicationLevel += 20;
		}
	}
	
}
