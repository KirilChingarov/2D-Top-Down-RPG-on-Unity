using System;
using Character;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        public float moveSpeed = 5f;
        private CharacterMovement characterMovement;
        
        private void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationContrller(GetComponentInChildren<CharacterAnimationController>());
        }

        private void FixedUpdate()
        {
            horizontalSpeed = Input.GetAxisRaw("Horizontal");
            verticalSpeed = Input.GetAxisRaw("Vertical");
            
            characterMovement.setCharacterVelocity(horizontalSpeed, verticalSpeed, moveSpeed);
        }
    }
}