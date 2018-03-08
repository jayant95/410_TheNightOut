using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	[SerializeField] [HideInInspector]
    public Stat health;


	[SerializeField] [HideInInspector]
    public Stat intoxication;



    public float moveSpeed;
	public float intoxicationLevel;
	public bool itemHeld = false;
	private GameObject pickup;
    public GameObject currentPlayer;
    private Animator currentAnimation;
    private float speedReducer;
	[HideInInspector] public bool isBoost = false;
	private float boostMultiplier = 1.0f;
	private int boostTimer;
	public GameObject playerAttackTrigger;


	// Use this for initialization
	void Start () {
        speedReducer = 1.0f;
		moveSpeed = 3.0f;
		intoxicationLevel = 0.0f;
		boostTimer = 180 * (int)(speedReducer * 1.8f);
        currentAnimation = currentPlayer.GetComponent<PlayerSwitch>().currentAnimation;
    }

    private void Awake()
    {
        health.Initialize();
        intoxication.Initialize();
    }

    // Update is called once per frame
    void Update () {
        currentAnimation = currentPlayer.GetComponent<PlayerSwitch>().currentAnimation;

		if (gameObject.GetComponent<Rigidbody2D> ().IsSleeping()) {
			gameObject.GetComponent<Rigidbody2D> ().WakeUp ();
		}

		movePlayer ();
		drainIntoxication (0.05f);
		increaseRange ();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            health.CurrentVal += 10;
        }
    }


	void drunkMovement() {

		float factor = (100 - intoxication.CurrentVal) / 100;
		moveSpeed = moveSpeed * factor;
		Debug.Log (moveSpeed);

	}

	void movePlayer() {

        ///drunkMovement ();
        speedReducer = 1.0f - (intoxication.CurrentVal / 200.0f);

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

        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.position += Vector3.down * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
            //transform.eulerAngles = new Vector2(0, 180);
            playerAttackTrigger.transform.eulerAngles = new Vector2(0, 0);
            currentAnimation.SetBool("WalkDown", true);
        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.position += Vector3.up * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
           // transform.eulerAngles = new Vector2(0, 180);
            playerAttackTrigger.transform.eulerAngles = new Vector2(0, 0);
            currentAnimation.SetBool("WalkUp", true);
        }



        else
        {
            currentAnimation.SetBool("Walk", false);
            currentAnimation.SetBool("WalkUp", false);
            currentAnimation.SetBool("WalkDown", false);
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

   

		if (Input.GetKey (KeyCode.UpArrow)) {
			//drunkMovement ();
			transform.position += Vector3.up * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
            currentAnimation.SetBool("WalkUp", true);
            currentAnimation.SetBool("WalkDown", false);
            currentAnimation.SetBool("Walk", false);
        }
		if (Input.GetKey (KeyCode.DownArrow)) {
			//drunkMovement ();
			transform.position += Vector3.down * moveSpeed * speedReducer * boostMultiplier * Time.deltaTime;
            currentAnimation.SetBool("WalkDown", true);
            currentAnimation.SetBool("WalkUp", false);
            currentAnimation.SetBool("Walk", false);
        }
 */


        if (isBoost) {
			boostMultiplier = 2.0f;
			boostTimer--;
			//Debug.Log (boostTimer);
		}

		if (boostTimer <= 0) {
			isBoost = false;
			boostMultiplier = 1.0f;
			boostTimer = 180 * (int)(speedReducer * 1.8f);
		}
	}
		

	void increaseRange() {
		float scale = ((intoxication.CurrentVal / 100.0f) * 2) + 1;
		float y = playerAttackTrigger.GetComponent<BoxCollider2D> ().size.y;
		playerAttackTrigger.GetComponent<BoxCollider2D> ().size = new Vector2 (scale * 3, y);
	}

	void drainIntoxication(float factor) {
		if (intoxication.CurrentVal > 0) {
            intoxication.CurrentVal = intoxication.CurrentVal - (1 * factor);
			intoxicationLevel = (1 * factor);
		//	Debug.Log ("Intoxication Level: " + intoxicationLevel);
		} else {
            intoxication.CurrentVal = 0;
			intoxicationLevel = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Alcohol") {
			Destroy (other.gameObject);
            intoxication.CurrentVal += 20;
			intoxicationLevel += 20;
		}

		if (other.name == "POPO")
        {
            Destroy(other.gameObject);
            intoxication.CurrentVal += 20;
        }


        if (other.name == "Coffee") {
			isBoost = true;
			Destroy (other.gameObject);
			if (intoxication.CurrentVal >= 20) {
                intoxication.CurrentVal -= 20;
				intoxicationLevel -= 20;
			} else if (intoxication.CurrentVal > 0 && intoxication.CurrentVal < 20) {
                intoxication.CurrentVal = 0;
				intoxicationLevel = 0;
			} else {
				// if intoxication is already 0 then don't destroy the object
				// tell the user that they are already have 0 intoxication
				// Debug.Log("Intoxication level is already 0!");
			}
		}

	}

}
