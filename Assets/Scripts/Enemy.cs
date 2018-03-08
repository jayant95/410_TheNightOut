using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
        curHealth -= damage;
        Debug.Log("damage");
    }
}
