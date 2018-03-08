using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {

	public GameObject laser;
	public GameObject player;
	private bool check;
	private bool onLaser = false;
	public bool needKey = false;
	public GameObject textPopup;

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
		if (other.name == "Rock" || other.name == "Key") {
			onLaser = true;
			if (!check) {

				//Destroy(laser);
			}
		}

		if (other.tag == "Player" && !needKey) {
			onLaser = true;
		}

		if (needKey) {
			if (other.name == "Player" && other.name != "Key") {
				// Show text
				textPopup.SetActive(true);
			}

			if (other.name == "Key") {
				// Don't show text
				textPopup.SetActive(false);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			onLaser = false;
		}

		if (other.name == "Rock") {
			onLaser = false;
		}

		if (needKey) {
			if (other.name == "Player") {
				textPopup.SetActive (false);
			}
		}

	}
}
