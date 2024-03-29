﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D theRB;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;
    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private Animator anim;
    public GameObject fireObject;
    public Transform throwPoint;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            //velicty ---speed
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKey(throwBall))
        {
            GameObject ballClone = (GameObject)Instantiate(fireObject, throwPoint.position, throwPoint.rotation);
            if (transform.localScale.x < 0)
                ballClone.transform.localScale = - ballClone.transform.localScale;
            if (theRB.velocity.x > 0)
                ballClone.transform.localScale = ballClone.transform.localScale;
            anim.SetTrigger("Throw");
        }
         
        if (theRB.velocity.x<0)
        {
            transform.localScale = new Vector3((float)-0.3493125, (float)0.2591, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3((float)0.3493125, (float)0.2591, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
}
