using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }


    void Update()
    {
        if (isDashing == false)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        }



        //if Input.GetKeySpace then isDashing == true
        if (Input.GetKey(KeyCode.Space))
        {
            isDashing = true;
        }

        if (isDashing == false)
        {
            if (Input.GetKeyDown(KeyCode.A)) //Change these to WASD
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                isDashing = false; //Change isDashing to equal false again
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    moveVelocity = Vector2.left * dashspeed;
                }
                else if (direction == 2)
                {
                    moveVelocity = Vector2.right * dashspeed;
                }
                else if (direction == 3)
                {
                    moveVelocity = Vector2.up * dashspeed;
                }
                else if (direction == 4)
                {
                    moveVelocity = Vector2.down * dashspeed;
                }

                Debug.Log(moveVelocity);
            }
        }
    }
}

