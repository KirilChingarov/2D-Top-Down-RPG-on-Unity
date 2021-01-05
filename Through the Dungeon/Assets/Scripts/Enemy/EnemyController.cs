using System.Collections;
using System.Collections.Generic;
using Character;
using DatabasesScripts;
using UnityEngine;
using Pathfinding;

namespace Enemy
{
    
    public class EnemyController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        private float moveSpeed = 1f;
        private CharacterMovement characterMovement;
        private EnemyDatabaseConn dbConn;

        private Transform target;
        private float nextWaypointDistance = 1.3f;
        private Path aiPath;
        private int currentWaypoint;
        private bool reachedEndOfPath = false;
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

            seeker.StartPath(characterMovement.getCurrentPosition(), target.position, onPathComplete);
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
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)aiPath.vectorPath[currentWaypoint] - characterMovement.getCurrentPosition()).normalized;
            Vector2 force = direction * (moveSpeed * Time.deltaTime);
        }
    }

}