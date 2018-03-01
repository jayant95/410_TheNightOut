using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

    public int damage = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
      

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

    }
}
