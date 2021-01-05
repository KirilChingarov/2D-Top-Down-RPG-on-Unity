using System.Collections;
using System.Collections.Generic;
using Character;
using DatabasesScripts;
using UnityEngine;

namespace Enemy
{
    
    public class EnemyController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        public float moveSpeed = 1f;
        private CharacterMovement characterMovement;
        private EnemyDatabaseConn dbConn;
        
        void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationContrller(GetComponentInChildren<CharacterAnimationController>());
            dbConn = new EnemyDatabaseConn("CharacterMovement.db", "testEnemyCharacter");
            moveSpeed = dbConn.getEnemyMoveSpeed();
        }
        
        void FixedUpdate()
        {
            
        }
    }

}