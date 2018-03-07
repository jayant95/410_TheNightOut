using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour {

	public GameObject roof;
	private Color color;
	private bool inRange = false;
	private float transparency = 1;
	public float minimum = 0.0f;
	public float maximum = 1f;
	public float duration = 6.0f;
	private float startTime;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		color = roof.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange) {
			fadeOut ();
		}

		if (roof.GetComponent<SpriteRenderer> ().color.a <= 0) {
			Destroy (roof);
		}
	}

	void fadeOut() {
		float t = (Time.time - startTime) / duration;
		roof.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, Mathf.SmoothStep(maximum, minimum, t));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			inRange = true;
		}

	}
}
