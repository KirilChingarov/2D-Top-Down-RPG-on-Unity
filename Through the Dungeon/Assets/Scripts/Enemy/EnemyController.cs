using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Combat.Enemy;
using DatabasesScripts;
using Enums;
using UnityEngine;
using Pathfinding;
using Player;
using UIScripts;
using UnityEngine.Assertions.Comparers;

namespace Enemy
{
    
    public class EnemyController : MonoBehaviour
    {
        private CharacterMovement characterMovement;
        private EnemyDatabaseConn DBConn;
        private CharacterStats characterStats;
        private bool isDead = false;

        private Transform target;
        private float nextWaypointDistance = 2f;
        private Path AIPath;
        private int currentWaypoint;
        private bool playerInRange = false;
        private Seeker seeker;

        private EnemyAttackController enemyAttackController;
        private bool canMove = true;
        private float nextAttack = 0f;

        private bool playerDead = false;
        public AggroRange aggroRange;
        public HealthBar healthBar;
        
        void Awake()
        {
            string characterName = "";
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.SetRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.SetCharacterAnimationController(GetComponentInChildren<CharacterAnimationController>());
            characterName = gameObject.name;
            DBConn = new EnemyDatabaseConn(characterName);
            characterStats = new CharacterStats(DBConn);
            healthBar.SetMaxHealth(characterStats.GETHealth());
            isDead = false;

            enemyAttackController = GetComponentInChildren<EnemyAttackController>();
            enemyAttackController.SetAttackRange(characterStats.GETAttackRange());
            enemyAttackController.SetBasicAttackDamage(characterStats.GETAttackDamage());

            target = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
            seeker = GetComponent<Seeker>();

            InvokeRepeating("UpdatePath", 0f, 0.5f);
        }

        private void UpdatePath()
        {
            if(playerInRange || playerDead) return;
            if (!aggroRange.IsPlayerInAggroRange())
            {
                AIPath = null;
            }
            else if (seeker.IsDone())
            {
                seeker.StartPath(characterMovement.GETCurrentPosition(), target.position, ONPathComplete);
            }
        }

        private void ONPathComplete(Path path)
        {
            if (!path.error)
            {
                AIPath = path;
                currentWaypoint = 0;
            }
        }
        
        void FixedUpdate()
        {
            if(playerDead) return;
            Move();
            Attack();
        }

        private void Attack()
        {
            if (playerInRange && Time.time >= nextAttack && !isDead)
            {
                if (gameObject.transform.position.x > target.position.x)
                {
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                enemyAttackController.Attack();
                nextAttack = Time.time + characterStats.GETAttackCooldown();
            }
        }

        private void Move()
        {
            if (AIPath == null)
            {
                characterMovement.SetCharacterVelocity(new Vector2(0f, 0f));
                characterMovement.SetCharacterDirection(Direction.Idle);
                return;
            }

            Vector2 force;
            Direction targetDirection;
            
            if (playerInRange || !canMove || GameObject.Find("PlayerCharacter").GetComponent<PlayerController>().GETIsSwimming())
            {
                force = new Vector2(0f, 0f);
                targetDirection = Direction.Idle;
            }
            else if (currentWaypoint >= AIPath.vectorPath.Count)
            {
                return;
            }
            else
            {
                float moveSpeed = characterStats.GETMoveSpeed();
                Vector2 direction = ((Vector2)AIPath.vectorPath[currentWaypoint] - characterMovement.GETCurrentPosition()).normalized;
                force = direction * (moveSpeed * Time.deltaTime);

                float distance = Vector2.Distance(characterMovement.GETCurrentPosition(),
                    AIPath.vectorPath[currentWaypoint]);
                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }

                targetDirection = characterMovement.GETDirectionFromVector(GETVectorToTarget());
            }
            
            characterMovement.SetCharacterVelocity(force);
            characterMovement.SetCharacterDirection(targetDirection);
        }

        private Vector2 GETVectorToTarget()
        {
            Vector2 currPosition = characterMovement.GETCurrentPosition();
            Vector2 targetPosition = target.position;

            float distanceX = targetPosition.x - currPosition.x;
            float distanceY = targetPosition.y - currPosition.y;
            
            return new Vector2(distanceX, distanceY);
        }

        public void SetReachedEndOfPath(bool check)
        {
            playerInRange = check;
        }

        public void FreezePosition()
        {
            canMove = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public void UnfreezePosition()
        {
            canMove = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            ResetScale();
        }

        public void ResetScale()
        {
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        public void TakeDamage(float damage)
        {
            characterStats.TakeDamage(damage);
            healthBar.TakeDamage(damage);
            if (characterStats.GETHealth() < Mathf.Epsilon && !isDead)
            {
                isDead = true;
                GetComponentInChildren<CharacterAnimationController>().CharacterDeath();
            }
            else if(!isDead)
            {
                GetComponentInChildren<CharacterAnimationController>().TakeHit();
            }
        }

        public void PlayerIsDead()
        {
            playerDead = true;
            characterMovement.SetCharacterDirection(Direction.Idle);
        }
    }

}