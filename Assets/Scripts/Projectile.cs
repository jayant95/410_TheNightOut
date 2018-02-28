using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject currentPlayer;
	private Transform playerTransform;
	private float garbageInterval = 2.0f;
	private float throwRate = 2.0f;
	public Transform throwPoint;
	public GameObject garbagePiece;
	private float minDistance = 5.0f;

	// Use this for initialization
	void Start () {
		playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;
	}
	
	// Update is called once per frame
	void Update () {
		playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;


		if (Vector2.Distance (transform.position, playerTransform.position) <= minDistance) {
			if (Time.time > garbageInterval) {
				garbageInterval = Time.time + throwRate;
				Instantiate (garbagePiece, throwPoint.position, throwPoint.rotation);
			}
		}
	}
}
