using UnityEngine;
using System.Collections;

public class DistortCamera : MonoBehaviour {

	// Camera shake taken and modified from http://www.mikedoesweb.com/2012/camera-shake-in-unity/
	public float playerIntoxication;
	public int fieldOfView;
	public GameObject playerObject;
	public GameObject currentPlayer;
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;
	public int spinRange;
	public int rotation;

	// Use this for initialization
	void Start () {
		fieldOfView = 50;
		spinRange = 0;
		rotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
		playerObject = currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer;
		playerIntoxication = playerObject.GetComponent<Player> ().intoxicationLevel;
		Camera.main.fieldOfView = 50 - (playerIntoxication/2);

		spinRange = (int)(playerIntoxication);

		/*
		while (rotation < spinRange) {
			rotation++;
			if (rotation >= spinRange) {
				break;
			}
		}
			

		if (playerIntoxication == 0) {
			//transform.Rotate(new Vector3 (0, 0, 0));
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else {
			transform.Rotate (new Vector3 (0, 0, playerIntoxication / 100));
			//transform.rotation = Quaternion.Euler(0, 0, playerIntoxication/10);
		}



		transform.Rotate(new Vector3(0, 0, playerIntoxication) * Time.deltaTime);
		*/
		if (shake_intensity > 0) {
			transform.position = transform.position + Random.insideUnitSphere * shake_intensity;
			shake_intensity -= shake_decay;
		}
		shake (playerIntoxication/1000.0f);
	}

	void shake(float intensity) {
		//originPosition = transform.position;
		shake_intensity = intensity;
		shake_decay = 0.005f;
	}
	/*
	IEnumerator Rotate(float duration) {
		Quaternion startRot = transform.rotation;
		float t = 0.0f;
		while ( t  < duration )
		{
			t += Time.deltaTime;
			transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.right); //or transform.right if you want it to be locally based
			yield return null;
		}
		transform.rotation = startRot;
	}
	*/

	
}
