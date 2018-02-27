using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractScript : MonoBehaviour {

    public GameObject currentPlayer;
    private Transform playerTransform;
	private GameObject playerObject;
    private float moveSpeed = 0.8f;
    private int maxDistance = 10;
    private int minDistance = 5;

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



        if (Vector2.Distance(transform.position, playerTransform.position) <= minDistance) {
           // transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
			transform.position = Vector2.Lerp (transform.position, playerObject.transform.position, Time.deltaTime * moveSpeed);
			if (Vector2.Distance(transform.position, playerTransform.position) <= maxDistance) {
                // call any functon, shoot or anything
            }
        }
        
	}
}
