using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour {


	private Vector2 velocity;

	//smoothing time for the camera
	public float smoothingTimer_y;
	public float smoothingTimer_x;

	//GameObject player
	private GameObject player;

	//bound the camera: make boundaries
	public bool bounds;

	//the min and max pos of the camera
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;


	void Start () {
		//find the player object
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	//smoothing the camera
	void FixedUpdate () {

		//smooth the x and y positions
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothingTimer_x);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothingTimer_y);

		//set the position of the camera's X and Y axises
		transform.position = new Vector3 (posX, posY, transform.position.z);


		//check the bounds of the camera
		if (bounds) {
			//clamp the position of the camera to the min and max values
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), 
				Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

		}
	}

	//set the min and max cam position
	//need to be public so CameraFollowEditor.cs can access those functions!
	//get position from the customized editor
	public void SetMinCamPosition(){
		minCameraPos = gameObject.transform.position;
	}

	public void SetMaxCamPosition(){
		maxCameraPos = gameObject.transform.position;
	}
}
