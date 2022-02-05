using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public float walkSpeed;
    public bool mustPetrol;
    public bool mustFlip;
    public Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundLayer;


    private void Awake()
    {
        mustPetrol = true;
    }

    private void FixedUpdate()
    {
        if(mustPetrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }
    private void Update()
    {
        if (mustPetrol)
        {
            Petrol();
        }
    }

    private void Petrol()
    {
        if(mustFlip)
        {
            Flip();
        }
        rb2d.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }
    
    void Flip()
    {
        mustPetrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPetrol = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
    
    
    
    
}
