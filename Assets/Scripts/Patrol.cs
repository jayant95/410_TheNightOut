using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	public Transform point1;
	public Transform point2;
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

		playerSeen = enemy.GetComponent<AttractScript> ().playerSeen;

		if (!playerSeen) {
			anim.SetBool ("Walking", true);
			if (moveRight) {
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			} else {
				transform.Translate (-Vector2.right * speed * Time.deltaTime);
			}

			if (moveRight && (Vector2.Distance (transform.position, point2.position) <= 0.5f)) {
				transform.localScale = new Vector2 (-scale_x, scale_y);
				//transform.eulerAngles = new Vector2(0, 180);
				moveRight = false;
			}

			if (!moveRight && (Vector2.Distance (transform.position, point1.position) <= 0.5f)) {
				//transform.eulerAngles = new Vector2(0, 0);
				transform.localScale = new Vector2 (scale_x, scale_y);
				moveRight = true;
			}
		}

        else {
			anim.SetBool ("Walking", false);
		}

	}

}
