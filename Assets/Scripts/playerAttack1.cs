using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack1 : MonoBehaviour {

    public AudioClip punchWhoosh;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;

    [HideInInspector] public bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 30.0f;

    public Collider2D attackTrigger;

    private Animator anim;

   void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
       anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }


	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F) && !attacking)
        {

            float vol = Random.Range(volLowRange, volHighRange);
            attacking = true;
            attackTimer = attackCd;
            source.PlayOneShot(punchWhoosh, vol);
            Debug.Log("salkdjaskldj");
            attackTrigger.enabled = true;
        }

        if(attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer--;
            }

            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
		}

        anim.SetBool("Attacking", attacking);

    }
}
