using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackAOE : MonoBehaviour
{

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.5f;

    public Collider2D attackTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = true;
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }

            else
            {

            }
        }

        anim.SetBool("Attacking", attacking);

    }
}
