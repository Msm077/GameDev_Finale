using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float bounce;
    public float bounceCooldown;
    public float hopCooldown;
    public float bounceTime;
    public float hopTime;
    public bool rightBounce;
    public bool rightHop;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if (bounceCooldown <= 0 && hopCooldown <= 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
                
            }
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
        else if (bounceCooldown > 0)
        {
            if (rightBounce == true)
            {
                rb.velocity = new Vector2(-bounce, 0.12f * bounce);
            }
            else
            {
                rb.velocity = new Vector2(bounce , 0.12f * bounce);
            }
            bounceCooldown -= Time.deltaTime; 
        }
        else if (hopCooldown > 0) 
        {
            hopCooldown -= Time.deltaTime;
            if (rightHop == true)
            {
                rb.velocity = new Vector2(-0.09f, 0.2f * bounce);
            }
            else
            {
                rb.velocity = new Vector2(0.09f, 0.2f * bounce);
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
    }
}