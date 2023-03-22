﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isJumping = false;

    //movement
    public Button moveLeftButton;
    public Button moveRightButton;

    //jump
    public Button jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Add listeners to movement buttons
        moveLeftButton.onClick.AddListener(MoveLeft);
        moveRightButton.onClick.AddListener(MoveRight);

        // Add a listener to the jump button's onClick event
        jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    void FixedUpdate()
    {
        // Check if the player is on the ground
        isJumping = false;
    }

    public void MoveLeft()
    {
        Debug.Log("MoveLeft");
        rb.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        Debug.Log("MoveRight");
        rb.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
    }

    public void OnJumpButtonClicked()
    {
        Debug.Log("Jump button clicked");
        if (isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
        }
    }

   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
   
}
