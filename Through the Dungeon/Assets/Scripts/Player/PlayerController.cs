using System;
using Character;
using DatabasesScripts;
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
            dbConn = new PlayerDatabaseConn("Player/CharacterMovement.db");
            dbConn.setMoveSpeed(moveSpeed);
            moveSpeed = dbConn.getPlayerMoveSpeed();
        }

        private void FixedUpdate()
        {
            horizontalSpeed = Input.GetAxisRaw("Horizontal");
            verticalSpeed = Input.GetAxisRaw("Vertical");
            
            characterMovement.setCharacterVelocity(horizontalSpeed, verticalSpeed, moveSpeed);
        }
    }
}