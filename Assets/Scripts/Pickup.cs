using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public bool canPickup = false;
	public Transform gamePlayer;
	public GameObject player;
	public bool holding = false;
	public GameObject currentPlayer;
	private Transform currentTransform;
	private int pickupCounter;
	public bool forPuzzle = false;
	private float currentIntoxication;
	private float velocity_y;
	private float velocity_x;
	private bool isPlayerBoost = false;
	private bool isThrown = false;
	private int travelTimer = 0;
	public bool intoxicationNeeded = false;

	// Use this for initialization
	void Start () {
		pickupCounter = 0;
		velocity_y = Random.Range(-0.05f, 0.05f);
		velocity_x = 4;
	}
	
	// Update is called once per frame
	void Update () {
		player = currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer;
		gamePlayer = currentPlayer.GetComponent<PlayerSwitch> ().currentTransform;
		currentIntoxication = player.GetComponent<Player> ().intoxicationLevel;
		isPlayerBoost = player.GetComponent<Player> ().isBoost;

		if (!intoxicationNeeded || currentIntoxication > 50.0f) {
			pickupObject ();
			calculateTimeThrown ();
		} else if (Input.GetKeyDown(KeyCode.Space) && currentIntoxication < 50.0f && canPickup){
			Debug.Log ("I need to be more drunk to pick that up!");
		}			

		if (gameObject.GetComponent<Rigidbody2D> ().IsSleeping()) {
			gameObject.GetComponent<Rigidbody2D> ().WakeUp ();
		}

	}

	void pickupObject() {
		if (Input.GetKeyDown (KeyCode.Space) && canPickup) {
			//transform.position = gamePlayer.position;
			transform.SetParent (gamePlayer);
			holding = true;
			player.GetComponent<Player> ().itemHeld = holding;
			pickupCounter++;
		}

		if (pickupCounter > 0 && pickupCounter % 2 == 0 && Input.GetKeyDown(KeyCode.Space) && canPickup) {
			holding = false;
			player.GetComponent<Player> ().itemHeld = holding;
			transform.SetParent (null);

			if (!forPuzzle) {
				if (isPlayerBoost) {
					currentIntoxication = 0;
				}
				isThrown = true;
				if (Input.GetAxisRaw ("Horizontal") > 0) {
					velocity_x = 4;
				} else {
					velocity_x = -4;
				}
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity_x, velocity_y * currentIntoxication);
			} 
		}
	}

	void calculateTimeThrown() {
		if (isThrown) {
			travelTimer++;
		}

		if (travelTimer > 90) {
			isThrown = false;
			travelTimer = 0;
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

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
