using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish1 : MonoBehaviour
{
    public AudioSource Win;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Win.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        }
    }

    
}
