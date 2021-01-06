using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using DatabasesScripts;
using Enums;
using UnityEngine;
using Pathfinding;

namespace Enemy
{
    
    public class EnemyController : MonoBehaviour
    {
        private float moveSpeed = 1f;
        private CharacterMovement characterMovement;
        private EnemyDatabaseConn dbConn;

        private Transform target;
        private float nextWaypointDistance = 2f;
        private Path aiPath;
        private int currentWaypoint;
        private bool playerHit = false;
        private Seeker seeker;
        
        void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationContrller(GetComponentInChildren<CharacterAnimationController>());
            dbConn = new EnemyDatabaseConn("CharacterMovement.db", "testEnemyCharacter");
            moveSpeed = dbConn.getEnemyMoveSpeed();

            target = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
            seeker = GetComponent<Seeker>();

            InvokeRepeating("UpdatePath", 0f, 0.5f);
        }

        private void UpdatePath()
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(characterMovement.getCurrentPosition(), target.position, onPathComplete);
            }
        }

        private void onPathComplete(Path path)
        {
            if (!path.error)
            {
                aiPath = path;
                currentWaypoint = 0;
            }
        }
        
        void FixedUpdate()
        {
            if (aiPath == null)
            {
                return;
            }

            if (currentWaypoint >= aiPath.vectorPath.Count)
            {
                return;
            }

            Vector2 force;
            Direction targetDirection;
            if (playerHit)
            {
                force = new Vector2(0f, 0f);
                targetDirection = Direction.IDLE;
            }
            else
            {
                Vector2 direction = ((Vector2)aiPath.vectorPath[currentWaypoint] - characterMovement.getCurrentPosition()).normalized;
                force = direction * (moveSpeed * Time.deltaTime);

                float distance = Vector2.Distance(characterMovement.getCurrentPosition(),
                    aiPath.vectorPath[currentWaypoint]);
                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }

                targetDirection = characterMovement.getDirectionFromVector(getVectorToTarget());
            }
            
            characterMovement.setCharacterVelocity(force);
            characterMovement.setCharacterDirection(targetDirection);
        }

        private Vector2 getVectorToTarget()
        {
            Vector2 currPosition = characterMovement.getCurrentPosition();
            Vector2 targetPosition = target.position;

            float distanceX = targetPosition.x - currPosition.x;
            float distanceY = targetPosition.y - currPosition.y;
            
            return new Vector2(distanceX, distanceY);
        }

        public void setReachedEndOfPath(bool check)
        {
            playerHit = check;
        }
    }

}