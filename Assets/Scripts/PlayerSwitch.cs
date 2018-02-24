﻿using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public Transform player1Trans;
	public Transform player2Trans;
    public Animator player1Anim;
    public Animator player2Anim;

	private bool player1Active = false;
	private bool player2Active = false;
	[HideInInspector] public GameObject currentPlayer;
	[HideInInspector] public Transform currentTransform;
    [HideInInspector] public Animator currentAnimation;

	// Use this for initialization
	void Start () {
		player1Active = true;
		currentPlayer = player1;
        currentAnimation = player1Anim;
        currentTransform = player1Trans;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("1")) {
			player1Active = true;
			player2Active = false;
		}

		if (Input.GetKeyDown ("2")) {
			player2Active = true;
			player1Active = false;
		}

		if (player1Active) {
			GameObject.Find ("Player").GetComponent<Player> ().enabled = true;
			GameObject.Find ("Player2").GetComponent<Player> ().enabled = false;
			currentPlayer = player1;
			currentTransform = player1Trans;
            currentAnimation = player1Anim;
		}

		if (player2Active) {
			GameObject.Find ("Player").GetComponent<Player> ().enabled = false;
			GameObject.Find ("Player2").GetComponent<Player> ().enabled = true;
			currentPlayer = player2;
			currentTransform = player2Trans;
            currentAnimation = player2Anim;
		}
	}
}
