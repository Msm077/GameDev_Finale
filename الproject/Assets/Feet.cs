using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour {

    
    public PlayerMovement playerMovement;
    public float hopCooldown;
    public AudioSource stomp;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weakness")
        {
            playerMovement.hopCooldown = playerMovement.hopTime;
            hopCooldown = Time.time + 0.3f;
            stomp.Play();
            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.rightHop = true;
            }
            else if (collision.transform.position.x < transform.position.x)
            {
                playerMovement.rightHop = false;
            }
            collision.gameObject.GetComponent<enemyMovement>().TakeDamage(1);


        }

    }
}
