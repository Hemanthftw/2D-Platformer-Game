using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController ScoreController;
    public Animator animator;
    public float speed;
    public float jumpForce;
    

    bool isGrounded;
    
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float crouch;

    internal void PickUpKey()
    {
        Debug.Log("Player has picked up the key");
        ScoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        animator.SetTrigger("Death");
        Debug.Log("Player got killed");
        Invoke("ReloadLevel", 2f);
       
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private Rigidbody2D rd2d;
   
    private void Awake()
    {
        Debug.Log("Player controller Awake");
        rd2d = gameObject.GetComponent<Rigidbody2D>();
    }
  
    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, vertical);
        PlayMomentAnimation(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        void Jump()
        {
            rd2d.velocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {


        

    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        
      
    
   }
    private void PlayMomentAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        
    }
   
 
    
    
  
    


    
}


    

