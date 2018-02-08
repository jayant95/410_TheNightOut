using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float rotationSpeed;
	public bool clockwise = false; 

	// Use this for initialization
	void Start () {
		rotationSpeed = 180;
	}
	
	// Update is called once per frame
	void Update () {

		if (clockwise) {
			rotationSpeed = -rotationSpeed;
		}

		if (Input.GetKey(KeyCode.R)) {
			transform.Rotate (0, 0, rotationSpeed);
		}
	}
}
