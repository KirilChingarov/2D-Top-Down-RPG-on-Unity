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
        private Rigidbody2D rb;
        private float projectileSpeed = 0f;
        private float projectileDamage = 0f;
        private float projectileRange = 0f;
        private Vector2 startingPoint;

        public void Start()
        {
            startingPoint = transform.position;
            rb = GetComponent<Rigidbody2D>();
            projectileSpeed = new AbilitiesDatabaseConn("RangedAttack").getProjectileSpeed();
            projectileDamage = new AbilitiesDatabaseConn("RangedAttack").getAbilityAttackDamage();
            projectileRange = new AbilitiesDatabaseConn("RangedAttack").getAbilityAttackRange();
            rb.velocity = transform.right * projectileSpeed;
            Debug.Log("startinPoint: " + startingPoint.x + ", " + startingPoint.y);
        }

        public void FixedUpdate()
        {
            if (Vector2.Distance(startingPoint, transform.position) >= projectileRange)
            {
                Destroy(gameObject);
                Debug.Log("Ability Reached projectileRange");
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyController>().takeDamage(projectileDamage);
            }
        }
    }
}