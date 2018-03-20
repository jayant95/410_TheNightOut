using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip hit;
    private AudioSource source;
    private float volLowRange = 0.1f;
    private float volHighRange = 0.4f;
    [SerializeField] [HideInInspector]
	public Stat health;

	[SerializeField]
	private CanvasGroup healthGroup;

    private Color color;
    public int maxHealth = 100;
    public int curHealth;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 6.0f;
    private float startTime;
    public bool isFromHallucination = false;
	public GameObject currentPlayer;
	private Transform playerTransform;
	private GameObject player;
	private Animator anim;
	public bool canAttack = false;
	public Collider2D colliderBox;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        color = this.GetComponent<SpriteRenderer>().color;
		if (isFromHallucination) {
			this.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
		}
        curHealth = maxHealth;
		if (canAttack) {
			anim = gameObject.GetComponent<Animator> ();
		}
    }

	private void awake() {
		health.Initialize();
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		if (canAttack) { 
			playerTransform = currentPlayer.GetComponent<PlayerSwitch>().currentTransform;
			player = currentPlayer.GetComponent<PlayerSwitch> ().currentPlayer;
		}
        if (isFromHallucination) {
            fadeIn();

			if (curHealth <= 0)
			{
				Destroy(this.gameObject);
			}
        }

        if (curHealth <= 0)
        {
            Destroy(this.gameObject);
        }

		if (canAttack) {
			transformEnemy ();
			attackPlayer ();
		}

		//Debug.Log (health.CurrentVal);

		if (Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentVal -= 10;
			Debug.Log ("decreasing");
		}
    }

	void transformEnemy() {
		if (Vector2.Distance (transform.position, playerTransform.position) <= 4.0f) {
			if (transform.position.x - playerTransform.position.x < 0) {
				transform.eulerAngles = new Vector2 (0, 0);
			} else {
				transform.eulerAngles = new Vector2 (0, 180);
			}
		}

	}

	void attackPlayer() {
		if (Vector2.Distance (transform.position, playerTransform.position) <= 1.5f) {
			anim.SetBool ("Attacking", true);
			anim.SetBool ("Walking", false);
			colliderBox.enabled = true;
			player.GetComponent<Player> ().health.CurrentVal -= 0.2f;
		} else {
			anim.SetBool ("Attacking", false);
			colliderBox.enabled = false;
		}
	}


    void fadeIn() {
        float t = (Time.time - startTime) / duration;
        this.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, Mathf.SmoothStep(minimum, maximum, t));
    }

    public void Damage(int damage)
    {
        float vol = Random.Range(volLowRange, volHighRange);
        if (!source.isPlaying)
        {
            source.PlayOneShot(hit, vol);
        }
        curHealth -= damage;
        Debug.Log("damage");

    }
}
