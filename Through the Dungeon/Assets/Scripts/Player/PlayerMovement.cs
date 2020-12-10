using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Enums;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float horizontalSpeed = 0f;
    public float verticalSpeed = 0f;
    private CharacterAnimationController characterGFX;
    private Direction currDirection = Direction.IDLE;
    public float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterGFX = GetComponentInChildren<CharacterAnimationController>();
    }

    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontalSpeed * moveSpeed, verticalSpeed * moveSpeed);
        
        currDirection = getDirectionFromSpeed(horizontalSpeed, verticalSpeed);
        characterGFX.ChangeDirection(currDirection);
    }

    private Direction getDirectionFromSpeed(float horizontalSpeed, float verticalSpeed)
    {
        if (verticalSpeed > 0.01f)
        {
            return Direction.UP;
        }
        else if(verticalSpeed < -0.01f)
        {
            return Direction.DOWN;
        }
        else if (horizontalSpeed > 0.01f)
        {
            return Direction.RIGHT;
        }
        else if(horizontalSpeed < -0.01f)
        {
            return Direction.LEFT;
        }
        return Direction.IDLE;
    }
}
