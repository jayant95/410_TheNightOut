using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject rotatingLaserFirst;
	public GameObject rotatingLaserSecond;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = 90.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			//if (Input.GetKey (KeyCode.Space)) {
			rotatingLaserFirst.transform.Rotate (0, 0, (rotationSpeed/2) * Time.deltaTime);
			if (rotatingLaserSecond) {
				rotatingLaserSecond.transform.Rotate (0, 0, (2* -rotationSpeed) * Time.deltaTime);
			}

			//}
		}

	}
}
