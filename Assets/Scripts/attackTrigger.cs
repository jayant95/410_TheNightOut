using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {


    public int damage = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Enemy") {
			collision.GetComponent<Enemy> ().curHealth -= damage;

		}
		/*
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			transform.eulerAngles = new Vector2(0, 0);
		} else if (Input.GetAxisRaw("Horizontal") < 0) {
			transform.eulerAngles = new Vector2(0, 90);
		}
		*/
      
		/*
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", damage);
             Debug.Log("damage", gameObject);

    
        }

       else if (collision.isTrigger != true && collision.CompareTag("Cop"))
        {
            collision.SendMessageUpwards("Damage", damage);
            Debug.Log("damage", gameObject);
        }
        else if (collision.isTrigger != true && collision.CompareTag("Drunk_Guy"))
        {
            collision.SendMessageUpwards("Damage", damage);
            Debug.Log("damage", gameObject);
        }
		*/

    }
}
