using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public bool canPickup = false;
	public Transform gamePlayer;
	public GameObject player;
	public bool holding = false;
	public GameObject currentPlayer;
	private Transform currentTransform;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		player = currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer;
		gamePlayer = currentPlayer.GetComponent<PlayerSwitch> ().currentTransform;

		if (Input.GetKeyDown (KeyCode.Space) && canPickup) {
			//transform.position = gamePlayer.position;
			transform.SetParent (gamePlayer);
			holding = true;
			player.GetComponent<Player> ().itemHeld = holding;
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			holding = false;
			player.GetComponent<Player> ().itemHeld = holding;
			transform.SetParent (null);
		}

		if (gameObject.GetComponent<Rigidbody2D> ().IsSleeping()) {
			gameObject.GetComponent<Rigidbody2D> ().WakeUp ();
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			canPickup = true;
			//player.GetComponent<Player> ().itemHeld = true;
			//transform.position = player.transform.position;
			//player.transform.SetParent (gamePlayer, false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			canPickup = false;
			holding = false;
			//player.GetComponent<Player> ().itemHeld = false;
		}
	}


}
