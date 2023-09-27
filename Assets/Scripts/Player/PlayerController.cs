using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float movSpeed = 1f;

    private Rigidbody2D rb;


    [SerializeField]private float maxReloadTime = 1f;
    private float reloadTime;


    [SerializeField] private AudioClip shootingClip;

    [SerializeField] private GameObject muzzle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        reloadTime = maxReloadTime;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        
    }

    void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (rb.position.x <= -9.9f)
        {
            if(horizontal > 0f)
            {
                rb.velocity = new Vector2(horizontal * movSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

        }
        else if(rb.position.x >= 9.9f)
        {
            if(horizontal < 0f)
            {
                rb.velocity = new Vector2(horizontal * movSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = new Vector2(horizontal * movSpeed, rb.velocity.y);
        }
        
    }

 
}
