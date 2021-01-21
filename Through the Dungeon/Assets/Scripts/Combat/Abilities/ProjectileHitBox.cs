using System;
using System.Security.Cryptography;
using Enemy;
using UnityEngine;

namespace Abilities
{
    public class ProjectileHitBox : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float projectileSpeed = 0f;
        private float projectileDamage = 0f;

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.forward * projectileSpeed;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyController>().takeDamage(projectileDamage);
            }
            else if (other.gameObject.tag == "Object")
            {
                Destroy(gameObject);
            }
        }

        public void setProjectile(float projectileSpeed, float projectileDamage)
        {
            this.projectileSpeed = projectileSpeed;
            this.projectileDamage = projectileDamage;
        }
    }
}