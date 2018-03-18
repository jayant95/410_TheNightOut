using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAI : MonoBehaviour {
	
	public GameObject currentPlayer;
	private Transform playerTransform;
	private GameObject playerObject;
	private bool moveRight;
	public float speed = 1.5f;
	private float scale_x;
	private float scale_y;
	private bool playerSeen;
	public GameObject enemy;
	private Animator anim;

	// Use this for initialization
	void Start () {
		moveRight = true;
		scale_x = transform.localScale.x;
		scale_y = transform.localScale.y;
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
