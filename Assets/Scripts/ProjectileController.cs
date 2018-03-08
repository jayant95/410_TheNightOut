﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	private int lifeTimer = 0;
	private GameObject playerObject;
	public GameObject currentPlayer;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-5.0f, 5.0f), Random.Range(2.0f, 2.0f));
		playerObject = currentPlayer.GetComponent<PlayerSwitch>().currentPlayer;
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer++;

		if (lifeTimer > 90) {
			this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			//this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 
			Physics.gravity = new Vector2(0, 0);
			if (gameObject.name == "garbage(Clone)") {
				Destroy (gameObject, 3);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Destroy (gameObject, 1);
			Debug.Log ("Hit Player!");
			playerObject.GetComponent<Player> ().health.CurrentVal -= 5;
			// Decrease player health
		}

		if (other.name == "Cop") {
			Destroy (gameObject, 1);
			Debug.Log ("Hit Cop!");
			// Decrease copy health
		}

	}
}
