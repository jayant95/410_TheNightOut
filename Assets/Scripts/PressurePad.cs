using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {

	public GameObject laser;
	public GameObject player;
	private bool check;
	private bool onLaser = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		check = player.GetComponent<Player> ().itemHeld;

		if (laser) {
			if (onLaser) {
				laser.SetActive (false);
			} else {
				laser.SetActive (true);
			}
		}

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.name == "Rock") {
			onLaser = true;
			if (!check) {

				//Destroy(laser);
			}
		}

		if (other.tag == "Player") {
			onLaser = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			onLaser = false;
		}

		if (other.name == "Rock") {
			onLaser = false;
		}	

	}
}
