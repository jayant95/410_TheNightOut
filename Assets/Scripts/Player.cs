using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public float intoxicationLevel;
	public bool itemHeld = false;
	private GameObject pickup;
    public GameObject currentPlayer;
    private Animator currentAnimation;
    private float speedReducer;
	private bool isBoost = false;
	private float boostMultiplier = 1.0f;
	private int boostTimer;
	public GameObject playerAttackTrigger;


	// Use this for initialization
	void Start () {
        speedReducer = 1.0f;
		moveSpeed = 3.0f;
		intoxicationLevel = 0.0f;
		boostTimer = 90 * (int)(speedReducer * 1.8f);
        currentAnimation = currentPlayer.GetComponent<PlayerSwitch>().currentAnimation;
    }

    // Update is called once per frame
    void Update () {
        currentAnimation = currentPlayer.GetComponent<PlayerSwitch>().currentAnimation;

		if (gameObject.GetComponent<Rigidbody2D> ().IsSleeping()) {
			gameObject.GetComponent<Rigidbody2D> ().WakeUp ();
		}

		movePlayer ();
		drainIntoxication (0.05f);

	}


	void drunkMovement() {

		float factor = (100 - intoxicationLevel) / 100;
		moveSpeed = moveSpeed * factor;
		Debug.Log (moveSpeed);

	}

	void movePlayer() {

        ///drunkMovement ();
        speedReducer = 1.0f - (intoxicationLevel / 100.0f);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
			transform.position += Vector3.right * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 0);
			playerAttackTrigger.transform.eulerAngles = new Vector2 (0, 180);
            currentAnimation.SetBool("Walk", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
			transform.position += Vector3.left * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 180);
			playerAttackTrigger.transform.eulerAngles = new Vector2 (0, 0);
            currentAnimation.SetBool("Walk", true);
        }
        else
        {
            currentAnimation.SetBool("Walk", false);
        }

        /*
        if (Input.GetKey (KeyCode.LeftArrow)) {
			//drunkMovement ();
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            anim.SetBool("Walk", true);
        }

		if (Input.GetKey (KeyCode.RightArrow)) {
			//drunkMovement ();
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            anim.SetBool("Walk", true);
            //anim.SetBool ("WalkRight", true);
        } else {
			//anim.SetBool ("WalkRight", false);
		}

    */

		if (Input.GetKey (KeyCode.UpArrow)) {
			//drunkMovement ();
			transform.position += Vector3.up * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			//drunkMovement ();
			transform.position += Vector3.down * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
		}



        if (isBoost) {
			boostMultiplier = 2.0f;
			boostTimer--;
			Debug.Log (boostTimer);
		}

		if (boostTimer <= 0) {
			isBoost = false;
			boostMultiplier = 1.0f;
			boostTimer = 90 * (int)(speedReducer * 1.8f);
		}
	}

	void drainIntoxication(float factor) {
		if (intoxicationLevel > 0) {
			intoxicationLevel = intoxicationLevel - (1 * factor);
		//	Debug.Log ("Intoxication Level: " + intoxicationLevel);
		} else {
			intoxicationLevel = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Alcohol") {
			Destroy (other.gameObject);
			intoxicationLevel += 20;
		}

        if (other.name == "POPO")
        {
            Destroy(other.gameObject);
            intoxicationLevel += 20;
        }


        if (other.name == "Coffee") {
			isBoost = true;
			Destroy (other.gameObject);
			if (intoxicationLevel >= 20) {
				intoxicationLevel -= 20;
			} else if (intoxicationLevel > 0 && intoxicationLevel < 20) {
				intoxicationLevel = 0;
			} else {
				// if intoxication is already 0 then don't destroy the object
				// tell the user that they are already have 0 intoxication
				// Debug.Log("Intoxication level is already 0!");
			}
		}

	}

}
