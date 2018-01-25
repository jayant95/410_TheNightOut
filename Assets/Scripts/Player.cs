using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		moveSpeed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}
	}
	
}
