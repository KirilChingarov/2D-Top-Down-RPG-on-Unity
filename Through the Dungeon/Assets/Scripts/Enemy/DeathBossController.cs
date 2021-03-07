using Character;
using DatabasesScripts;
using Enums;
using Pathfinding;
using Player;
using UIScripts;
using UnityEngine;

namespace Enemy
{
    public class DeathBossController : MonoBehaviour
    {
        private CharacterMovement m_CharacterMovement;
        private EnemyDatabaseConn m_DBConn;
        private CharacterStats m_CharacterStats;
        private bool m_IsDead = false;

        private Transform m_Target;
        private float m_NextWaypointDistance = 2f;
        private Path m_AIPath;
        private int m_CurrentWaypoint;
        private bool m_PlayerInRange = false;
        private Seeker m_Seeker;

        private EnemyAttackController m_EnemyAttackController;
        private bool m_CanMove = true;
        private float m_NextAttack = 0f;
        private float summonCooldown = 4f;
        private float m_NextSummon = 0f;

        private bool m_PlayerDead = false;
        public AggroRange aggroRange;
        public HealthBar healthBar;

        public GameObject deathGhost;
        public Transform spawnPoint;
        
        void Awake()
        {
            string characterName = "";
            m_CharacterMovement = GetComponent<CharacterMovement>();
            m_CharacterMovement.SetRigidBody2D(GetComponent<Rigidbody2D>());
            m_CharacterMovement.SetCharacterAnimationController(GetComponentInChildren<CharacterAnimationController>());
            characterName = gameObject.name;
            m_DBConn = new EnemyDatabaseConn(characterName);
            m_CharacterStats = new CharacterStats(m_DBConn);
            summonCooldown = new AbilitiesDatabaseConn("Summon").GETAbilityCooldown();
            m_NextSummon = Time.time + 2 * summonCooldown;
            healthBar.SetMaxHealth(m_CharacterStats.GETHealth());
            m_IsDead = false;

            m_EnemyAttackController = GetComponentInChildren<EnemyAttackController>();
            m_EnemyAttackController.SetAttackRange(m_CharacterStats.GETAttackRange());
            m_EnemyAttackController.SetBasicAttackDamage(m_CharacterStats.GETAttackDamage());

            m_Target = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
            m_Seeker = GetComponent<Seeker>();

            deathGhost.GetComponent<EnemyController>().aggroRange = aggroRange;

            InvokeRepeating("UpdatePath", 0f, 0.5f);
        }

        private void UpdatePath()
        {
            if(m_PlayerInRange || m_PlayerDead) return;
            if (!aggroRange.IsPlayerInAggroRange())
            {
                m_AIPath = null;
            }
            else if (m_Seeker.IsDone())
            {
                m_Seeker.StartPath(m_CharacterMovement.GETCurrentPosition(), m_Target.position, ONPathComplete);
            }
        }

        private void ONPathComplete(Path path)
        {
            if (!path.error)
            {
                m_AIPath = path;
                m_CurrentWaypoint = 0;
            }
        }
        
        void FixedUpdate()
        {
            if(m_PlayerDead) return;
            Move();
            Attack();
        }

        private void Attack()
        {
            if (m_PlayerInRange && Time.time >= m_NextAttack && !m_IsDead)
            {
                m_EnemyAttackController.BossAttack((DeathBossAttacks) Random.Range(0, 2));
                m_NextAttack = Time.time + m_CharacterStats.GETAttackCooldown();
            }
            else if (Time.time >= m_NextSummon && !m_IsDead && m_EnemyAttackController.GetCurrentAnimation() == "Idle")
            {
                m_EnemyAttackController.BossAttack(DeathBossAttacks.Summon);
                m_NextSummon = Time.time + summonCooldown;
            }
        }

        public void Summon()
        {
            GameObject deathGhostInstantiate = Instantiate(deathGhost, spawnPoint.position, spawnPoint.rotation);
            deathGhostInstantiate.name = "DeathGhost";
        }

        private void Move()
        {
            if (m_AIPath == null)
            {
                m_CharacterMovement.SetCharacterVelocity(new Vector2(0f, 0f));
                return;
            }

            Vector2 force;
            
            if (m_PlayerInRange || !m_CanMove || GameObject.Find("PlayerCharacter").GetComponent<PlayerController>().GETIsSwimming())
            {
                force = new Vector2(0f, 0f);
            }
            else if (m_CurrentWaypoint >= m_AIPath.vectorPath.Count)
            {
                return;
            }
            else
            {
                float moveSpeed = m_CharacterStats.GETMoveSpeed();
                Vector2 direction = ((Vector2)m_AIPath.vectorPath[m_CurrentWaypoint] - m_CharacterMovement.GETCurrentPosition()).normalized;
                force = direction * (moveSpeed * Time.deltaTime);

                float distance = Vector2.Distance(m_CharacterMovement.GETCurrentPosition(),
                    m_AIPath.vectorPath[m_CurrentWaypoint]);
                if (distance < m_NextWaypointDistance)
                {
                    m_CurrentWaypoint++;
                }
            }
            
            m_CharacterMovement.SetCharacterVelocity(force);
        }

        public void SetReachedEndOfPath(bool check)
        {
            m_PlayerInRange = check;
        }

        public void FreezePosition()
        {
            m_CanMove = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public void UnfreezePosition()
        {
            m_CanMove = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void TakeDamage(float damage)
        {
            m_CharacterStats.TakeDamage(damage);
            healthBar.TakeDamage(damage);
            if (m_CharacterStats.GETHealth() < Mathf.Epsilon && !m_IsDead)
            {
                m_IsDead = true;
                GetComponentInChildren<CharacterAnimationController>().CharacterDeath();
            }
        }

        public void PlayerIsDead()
        {
            m_PlayerDead = true;
            m_CharacterMovement.SetCharacterDirection(Direction.Idle);
        }
    }
}