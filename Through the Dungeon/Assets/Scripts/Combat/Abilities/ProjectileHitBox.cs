using DatabasesScripts;
using Enemy;
using UnityEngine;

namespace Combat.Abilities
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
            projectileSpeed = new AbilitiesDatabaseConn("RangedAttack").GETProjectileSpeed();
            projectileDamage = new AbilitiesDatabaseConn("RangedAttack").GETAbilityAttackDamage();
            projectileRange = new AbilitiesDatabaseConn("RangedAttack").GETAbilityAttackRange();
            rb.velocity = transform.right * projectileSpeed;
        }

        public void FixedUpdate()
        {
            if (Vector2.Distance(startingPoint, transform.position) >= projectileRange)
            {
                Destroy(gameObject);
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if(other.gameObject.GetComponent<EnemyController>() != null) other.gameObject.GetComponent<EnemyController>().TakeDamage(projectileDamage);
                else other.gameObject.GetComponent<DeathBossController>().TakeDamage(projectileDamage);
            }
        }
    }
}