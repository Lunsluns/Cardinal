using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask WhatIsGround;
    //speed stats
    public float MAXSPEED, moveSpeed, xspeed;
    public float jumpForce, secondJumpForce, jumpTime, secondJumpTime, jumpTimeCounter, secondJumpCounter;
    public AudioClip[] walk, jumping, pain; public AudioSource source;
    public Animator controller;

    //jump checks
    bool grounded;
    int TimesJumped;
    //Rigidbody2D for player
    private Rigidbody2D rigid2D;
    //Checks for ground and ceiling
    private Transform GroundCheck, CeilingCheck;
    const float GroundedRadius = 0.2f, CeilingRadius = 0.1f;
    //facing direction
    public bool facingRight = true;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        GroundCheck = transform.Find("GroundCheck");
        CeilingCheck = transform.Find("CeilingCheck");
    }

    void Start()
    {

        jumpTimeCounter = jumpTime;
        secondJumpCounter = secondJumpTime;
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            xspeed += Input.GetAxis("Horizontal") * (moveSpeed * (1 - Time.deltaTime));
            controller.SetFloat("speed", xspeed);
            if (!source.isPlaying)
            {
                source.clip = walk[Random.Range(0, walk.Length - 1)];
                source.Play();
            }
        }
        else
        {
            if ((xspeed > -0.45f && xspeed < 0.0f) || (xspeed > 0.45f && xspeed > 0.0f))
            {
                xspeed -= xspeed * 0.45f;
                if (!source.isPlaying)
                {
                    source.clip = walk[Random.Range(0, walk.Length - 1)];
                    source.Play();
                }
            }
            else
            {
                xspeed = 0; 
            }
            controller.SetFloat("speed", xspeed);
        }
        if (Mathf.Abs(xspeed) >= MAXSPEED)
        {
            xspeed = Input.GetAxis("Horizontal") * MAXSPEED;
        }
        rigid2D.velocity = new Vector2(xspeed, rigid2D.velocity.y);
        if (grounded == false && TimesJumped == 2)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x * 0.75f, rigid2D.velocity.y);
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
                TimesJumped = 0;
                controller.SetBool("jump", true);
                source.clip = jumping[0];
                source.Play();
            }
            else if (!grounded && TimesJumped < 2)
            {
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, secondJumpForce);
            }
        }

        if (Input.GetButton("Jump"))
        {
            if (TimesJumped == 0)
            {
                if (jumpTimeCounter > 0)
                {
                    rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;

                }
            }
            else if (TimesJumped == 1)
            {
                if (secondJumpCounter > 0)
                {
                    rigid2D.velocity = new Vector2(rigid2D.velocity.x * 0.75f, secondJumpForce);
                    secondJumpCounter -= Time.deltaTime;
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundedRadius, WhatIsGround);
        if (grounded)
        {
            controller.SetBool("jump", false);
            jumpTimeCounter = jumpTime;
            secondJumpCounter = secondJumpTime;
            TimesJumped = 0;
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (TimesJumped == 0)
            {
                jumpTimeCounter = 0;
                TimesJumped = 1;
            }
            else if (TimesJumped == 1)
            {
                secondJumpCounter = 0;
                TimesJumped = 2;
            }
        }
    }

    public void dead()
    {
        controller.SetTrigger("ded");
        float time = Time.time + 10;
        while(time > Time.time)
        {

        }
    }
    private void Flip()
    {
        //this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
    }
}
