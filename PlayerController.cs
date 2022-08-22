using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public float playerSpeed;
    public float jumpforce;
    private float playerMove;
    private bool isGrounded;
    public Transform feetpos;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    private bool isJumping;
    private float jumpTimeCounter;
    public float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        playerMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(playerMove * playerSpeed, rb.velocity.y);
    }

    
        

    


    // Update is called once per frame
    void Update()
    {
        flipcharacter();
        animator.SetFloat("Speed", Mathf.Abs(playerMove));
        isGrounded = Physics2D.OverlapCircle(feetpos.position, CheckRadius, WhatIsGround);
        if (isGrounded = true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            rb.velocity = Vector2.up * jumpforce;
        }


        if (Input.GetKeyUp(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
                rb.velocity = Vector2.up * jumpforce;
            jumpTimeCounter -= Time.deltaTime;
        }
        else 
        {
            isJumping = false;
        }
    }

    private void flipcharacter()
    {
      bool playermove = Mathf.Abs(rb.velocity.x)>0;
    if (playermove)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x)* 0.3978709f, 0.3978709f);
        }
    

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

}










