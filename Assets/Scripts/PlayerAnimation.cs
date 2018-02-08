using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	private Animator anim;
	//private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//rb = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		//anim.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetAxis("Horizontal") > 0) {
//			Debug.Log ("walking right");
//			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//			anim.Play ("walk");
//		} else if (Input.GetAxis("Horizontal") < 0) {
//			Debug.Log ("Walking Left");
//			anim.Play ("walkLeft");
//		} else {
//			anim.enabled = false;
//		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//drunkMovement ();
			//transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			anim.SetBool ("WalkRight", true);
		} else {
			anim.SetBool ("WalkRight", false);
		}
	}
}
