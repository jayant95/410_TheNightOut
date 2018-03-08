using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlcohol : MonoBehaviour {

	public GameObject powerUp;
	private bool isThere = true;
	private int spawnTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isThere) {
			spawnTimer++;
		}
			
		if (spawnTimer > 300) {
			Instantiate (powerUp, gameObject.transform.position, gameObject.transform.rotation);
			spawnTimer = 0;
			isThere = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			isThere = false;
		}

	}
}
