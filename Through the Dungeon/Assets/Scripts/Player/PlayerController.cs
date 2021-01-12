using System;
using Character;
using DatabasesScripts;
using Enums;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement characterMovement;
        private PlayerDatabaseConn dbConn;
        private CharacterStats characterStats;
        
        private void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationContrller(GetComponentInChildren<CharacterAnimationController>());
            dbConn = new PlayerDatabaseConn("CharacterStats.db");
            characterStats = new CharacterStats(dbConn);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float horizontalSpeed = Input.GetAxisRaw("Horizontal");
            float verticalSpeed = Input.GetAxisRaw("Vertical");
            float moveSpeed = characterStats.getMoveSpeed();

            Vector2 force = new Vector2(horizontalSpeed, verticalSpeed) * (moveSpeed * Time.deltaTime);
            Direction direction = characterMovement.getDirectionFromVector(force);
            characterMovement.setCharacterVelocity(force);
            characterMovement.setCharacterDirection(direction);
        }
    }
}