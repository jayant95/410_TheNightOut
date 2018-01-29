﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public float intoxicationLevel;

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
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Alcohol") {
			Destroy (other.gameObject);
			intoxicationLevel += 20;
		}
	}
	
}
