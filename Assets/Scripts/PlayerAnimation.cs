﻿using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
    // ** This script is obsolete. Animations are being done in Player.cs instead. Keep this file just in case

	//private Animator anim;

    // Use this for initialization
    void Start () {
		//anim = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetAxisRaw("Horizontal") > 0) {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetBool("Walk", true);
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
        }
        */
	}
}
