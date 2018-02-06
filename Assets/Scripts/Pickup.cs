using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public bool canPickup = false;
	public Transform gamePlayer;
	public GameObject player;
	public bool holding = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

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

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			Debug.Log ("here");
			canPickup = true;
			//player.GetComponent<Player> ().itemHeld = true;
			//transform.position = player.transform.position;
			//player.transform.SetParent (gamePlayer, false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Player") {
			canPickup = false;
			holding = false;
			//player.GetComponent<Player> ().itemHeld = false;
		}
	}


}
