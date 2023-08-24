using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Animator anim;
    private float hurtTime;
    private float deathAni;
    public AudioSource die;
    public AudioSource hurt;
    
    

    private void Start()
    {
        currentHealth = maxHealth;
        
        
        
    }

    private void Update()
    {
        if (Time.time - hurtTime > 0.7f) { 
            
            anim.SetBool("hurt", false);
        }
        if (Time.time >= deathAni && currentHealth <= 0) 
        {
            FindObjectOfType<GameManager2>().gameOver();
            Destroy(gameObject);
        }
        if (currentHealth == 0)
        {
            
            Destroy(GetComponentInChildren<BoxCollider2D>());
            Destroy(GetComponentInChildren<BoxCollider2D>());

        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurt.Play();
        anim.SetBool("hurt", true);
        hurtTime = Time.time;
        
;        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        deathAni = Time.time +1.5f;
        anim.SetBool("Dead", true);
        die.Play();
        
        
        
    }




}

