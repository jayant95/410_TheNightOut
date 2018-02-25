using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractScript : MonoBehaviour {

    public GameObject currentPlayer;
    private Transform playerTransform;
    private float moveSpeed = 1.4f;
    private int maxDistance = 10;
    private int minDistance = 5;

	// Use this for initialization
	void Start () {
        playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;
    }

    // Update is called once per frame
    void Update () {
        playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;

        transform.LookAt(playerTransform.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, playerTransform.position) <= minDistance) {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            if (Vector2.Distance(transform.position, playerTransform.position) <= maxDistance) {
                // call any functon, shoot or anything
            }
        }
	}
}
