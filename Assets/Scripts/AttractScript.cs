using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractScript : MonoBehaviour {

    public GameObject currentPlayer;
    private Transform playerTransform;
	private GameObject playerObject;
    private float moveSpeed = 0.8f;
    private int maxDistance = 10;
    private int minDistance = 4;
	public bool isFriendly = false;
	[HideInInspector] public bool playerSeen = false;

	private Vector2 velocity;

	//smoothing time for the camera
	public float smoothingTimer_y;
	public float smoothingTimer_x;

	// Use this for initialization
	void Start () {
        //playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;
		//playerObject = currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer;
    }

    // Update is called once per frame
    void Update () {
        playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;
		playerObject = currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer;


       // transform.LookAt(playerTransform.position);
       // transform.Rotate(new Vector3(0, -90, 0), Space.Self);

		//Vector2 vectorDifference = playerObject.transform.position - this.transform.position;
		//float arcTan = Mathf.Atan2 (vectorDifference.y, vectorDifference.x);
		//transform.rotation = Quaternion.Euler (0, 0, arcTan * Mathf.Rad2Deg);
		//transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, (arcTan * Mathf.Rad2Deg) - 90.0f), Time.deltaTime * 0.8f);

		if (isFriendly) {
			float posX = Mathf.SmoothDamp (transform.position.x, currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer.transform.position.x, ref velocity.x, smoothingTimer_x);
			float posY = Mathf.SmoothDamp (transform.position.y, currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer.transform.position.y, ref velocity.y, smoothingTimer_y);
			if (Vector2.Distance(transform.position, playerTransform.position) >= minDistance) {
				//transform.position = Vector2.Lerp (transform.position, playerObject.transform.position, Time.deltaTime * moveSpeed);
				transform.position = new Vector3 (posX, posY, transform.position.z);
			}

		} else {
			if (Vector2.Distance(transform.position, playerTransform.position) <= minDistance) {
				playerSeen = true;
				// transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
				transform.position = Vector2.Lerp (transform.position, playerObject.transform.position, Time.deltaTime * moveSpeed);
				if (Vector2.Distance(transform.position, playerTransform.position) <= maxDistance) {
					// call any functon, shoot or anything
				}
			}
		}

 
        
	}
}
