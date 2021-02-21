using System;
using System.Security.Cryptography;
using DatabasesScripts;
using Enemy;
using UnityEngine;
using UnityEngine.UIElements;

namespace Abilities
{
    public class ProjectileHitBox : MonoBehaviour
    {
        private Rigidbody2D m_Rb;
        private float m_ProjectileSpeed = 0f;
        private float m_ProjectileDamage = 0f;
        private float m_ProjectileRange = 0f;
        private Vector2 m_StartingPoint;

        public void Start()
        {
            m_StartingPoint = transform.position;
            m_Rb = GetComponent<Rigidbody2D>();
            m_ProjectileSpeed = new AbilitiesDatabaseConn("RangedAttack").GETProjectileSpeed();
            m_ProjectileDamage = new AbilitiesDatabaseConn("RangedAttack").GETAbilityAttackDamage();
            m_ProjectileRange = new AbilitiesDatabaseConn("RangedAttack").GETAbilityAttackRange();
            m_Rb.velocity = transform.right * m_ProjectileSpeed;
        }

        public void FixedUpdate()
        {
            if (Vector2.Distance(m_StartingPoint, transform.position) >= m_ProjectileRange)
            {
                Destroy(gameObject);
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyController>().TakeDamage(m_ProjectileDamage);
            }
        }
    }
}