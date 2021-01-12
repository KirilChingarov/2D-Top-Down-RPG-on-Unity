using System;
using Character;
using DatabasesScripts;
using Enums;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        public float moveSpeed = 1f;
        private CharacterMovement characterMovement;
        private PlayerDatabaseConn dbConn;
        
        private void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationContrller(GetComponentInChildren<CharacterAnimationController>());
            dbConn = new PlayerDatabaseConn("CharacterStats.db");
            moveSpeed = dbConn.getPlayerMoveSpeed();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            horizontalSpeed = Input.GetAxisRaw("Horizontal");
            verticalSpeed = Input.GetAxisRaw("Vertical");

            Vector2 force = new Vector2(horizontalSpeed, verticalSpeed) * (moveSpeed * Time.deltaTime);
            Direction direction = characterMovement.getDirectionFromVector(force);
            characterMovement.setCharacterVelocity(force);
            characterMovement.setCharacterDirection(direction);
        }
    }
}