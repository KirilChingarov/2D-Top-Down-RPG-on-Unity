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
        private PlayerAttackController playerAttackController;
        private bool canMove = true;
        private float nextAttack = 0f;
        
        private void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationContrller(GetComponentInChildren<CharacterAnimationController>());
            dbConn = new PlayerDatabaseConn("CharacterStats.db");
            characterStats = new CharacterStats(dbConn);
            playerAttackController = GetComponentInChildren<PlayerAttackController>();
            playerAttackController.setAttackRange(characterStats.getAttackRange());
        }

        private void FixedUpdate()
        {
            Move();
            Attack();
        }

        private void Move()
        {
            if(canMove != true) return;
            
            float horizontalSpeed = Input.GetAxisRaw("Horizontal");
            float verticalSpeed = Input.GetAxisRaw("Vertical");
            float moveSpeed = characterStats.getMoveSpeed();

            Vector2 force = new Vector2(horizontalSpeed, verticalSpeed) * (moveSpeed * Time.deltaTime);
            Direction direction = characterMovement.getDirectionFromVector(force);
            characterMovement.setCharacterVelocity(force);
            characterMovement.setCharacterDirection(direction);
        }

        private void Attack()
        {
            if (Input.GetMouseButton(0) && Time.time >= nextAttack)
            {
                //canMove = false;
                playerAttackController.Attack();
                nextAttack = Time.time + characterStats.getAttackCooldown();
            }
        }
    }
}