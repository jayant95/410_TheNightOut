using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {

	public GameObject laser;
	public GameObject player;
	private bool check;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		check = player.GetComponent<Player> ().itemHeld;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.name == "Rock") {
			if (!check) {
				Destroy (laser);
			}
		}
	}
}
