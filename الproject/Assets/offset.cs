using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class offset : MonoBehaviour
{
    public playerHealth playerHealth;
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    { 
        if (collision2D.gameObject.tag == "Player") 
        {
            playerHealth.currentHealth = 0;
            playerHealth.Die();
            
        }
    }
   
}
