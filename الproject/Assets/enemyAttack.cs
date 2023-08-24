using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int damage =1;
    public playerHealth playerHealth;
    public PlayerMovement playerMovement;
    private float enemyCooldowm;
    public enemyMovement enemyMovement;
    public Feet feet;
  
    void Update()
    {
        if ( Time.time < enemyCooldowm || Time.time < feet.hopCooldown) 
        {
            enemyMovement.enabled = false;
            enemyMovement.anim.enabled = false;
            
        }
        else
        {
            enemyMovement.enabled=true;
            enemyMovement.anim.enabled = true;

        }
      
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerMovement.bounceCooldown = playerMovement.bounceTime;
            enemyCooldowm = Time.time + 1;
           
            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.rightBounce = false;
            }
            else if (collision.transform.position.x < transform.position.x)
            {
                playerMovement.rightBounce = true;
            }
                playerHealth.TakeDamage(damage);
            
        }
            
        }

    }
    


