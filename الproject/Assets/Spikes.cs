using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 1;
    public playerHealth playerHealth;
    public PlayerMovement playerMovement;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            

            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.rb.velocity = new Vector2(0.2f, 10);
            }
            else if (collision.transform.position.x < transform.position.x)
            {
                playerMovement.rb.velocity = new Vector2(-0.2f, 10);
            }
            playerHealth.TakeDamage(damage);

        }

    }

}
