using System;
using DatabasesScripts;
using Player;
using UnityEngine;

namespace Traps
{
    public class Arrow : MonoBehaviour
    {
        private float projectileSpeed;
        private float projectileDamage;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            projectileSpeed = new TrapsDatabaseConn("Cannon").getTrapProjectileSpeed();
            projectileDamage = new TrapsDatabaseConn("Cannon").getTrapDamage();
            rb.velocity = rb.velocity = transform.up * projectileSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().takeDamage(projectileDamage);
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "Object")
            {
                Destroy(gameObject);
            }
        }
    }
}