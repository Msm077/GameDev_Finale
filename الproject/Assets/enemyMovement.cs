using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyMovement : MonoBehaviour {
    private Rigidbody2D rb;
    public Animator anim;
    public GameObject A;
    public GameObject B;
    private Transform nextstop;
    public Transform playerTransform;
    public float r;
    public float chaseDis = 7.0f;
    public float speed = 8.0f;
    private bool isChasing = false;
    private bool isFacingRight = true;
    public int maxHP = 2;
    public int HP;
    private float deathCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        HP = maxHP;
        nextstop = B.transform;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFacingRight == false && nextstop == B.transform)

            {
                Vector3 localscale = transform.localScale;
                localscale.x = (-localscale.x);
                transform.localScale = localscale;
                isFacingRight = !isFacingRight;


            }

        if (isFacingRight == true && nextstop == A.transform)
        {
            Vector3 localscale = transform.localScale;
            localscale.x = (-localscale.x);
            transform.localScale = localscale;
            isFacingRight = !isFacingRight;

        }

        if (isChasing)
        {

                if (transform.position.x > playerTransform.position.x)
            {
                rb.velocity = new Vector2(-speed, 0f);
                transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);


            }
            else if (transform.position.x < playerTransform.position.x)
            {
                rb.velocity = new Vector2(speed, 0f);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (Vector2.Distance(transform.position, playerTransform.position) > chaseDis)
            {
                if (transform.localScale.x > 0) { isFacingRight = true; }
                else { isFacingRight = false; }
                isChasing = false;
            }
        }
        else if (isChasing == false)
        {
            if (transform.position.x < A.transform.position.x)
            {

                nextstop = B.transform;
                rb.velocity = new Vector2(speed, 0);
              

            }
            else if (transform.position.x > B.transform.position.x)
            {
                nextstop = A.transform;
                rb.velocity = new Vector2(-speed, 0);

            }
            if (transform.position.x > A.transform.position.x & transform.position.x < B.transform.position.x)
            {
                if (nextstop == B.transform)
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                else if (nextstop == A.transform)
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
                if (Vector2.Distance(transform.position, nextstop.position) < r && nextstop == B.transform)
                {
                    
                    nextstop = A.transform;
                }
                else if (Vector2.Distance(transform.position, nextstop.position) < r && nextstop == A.transform)
                {
                    
                    nextstop = B.transform;
                }
            }
                if (Vector2.Distance(transform.position, playerTransform.position) < chaseDis && Mathf.Abs(transform.position.y-playerTransform.position.y)<2f)
                {
                    isChasing = true;
                }
                
            }
        if (Time.time - deathCooldown > 0.7 && anim.GetBool("Dead?") == true)
        {
            Destroy(gameObject);
        }
        if (HP == 0)
        {
            Destroy(GetComponent<CapsuleCollider2D>());
            Destroy(GetComponentInChildren<BoxCollider2D>());
            
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(A.transform.position, r);
        Gizmos.DrawWireSphere(B.transform.position, r);
        Gizmos.DrawLine(A.transform.position, B.transform.position);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            deathCooldown = Time.time;
            anim.SetBool("Dead?", true);
            
        }
    }

}
