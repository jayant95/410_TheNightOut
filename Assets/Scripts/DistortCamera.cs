using UnityEngine;
using System.Collections;

public class DistortCamera : MonoBehaviour {

	// Camera shake taken and modified from http://www.mikedoesweb.com/2012/camera-shake-in-unity/
	public float playerIntoxication;
	public int fieldOfView;
	public GameObject playerObject;

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;

	// Use this for initialization
	void Start () {
		fieldOfView = 50;
	}
	
	// Update is called once per frame
	void Update () {
		playerIntoxication = playerObject.GetComponent<Player> ().intoxicationLevel;
		Camera.main.fieldOfView = 50 - (playerIntoxication/2);

		if (shake_intensity > 0) {
			transform.position = transform.position + Random.insideUnitSphere * shake_intensity;
			shake_intensity -= shake_decay;
		}
		shake (playerIntoxication/500.0f);
	}

	void shake(float intensity) {
		//originPosition = transform.position;
		shake_intensity = intensity;
		shake_decay = 0.002f;
	}


	
}
