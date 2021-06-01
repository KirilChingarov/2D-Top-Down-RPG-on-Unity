using System;
using DatabasesScripts;
using Player;
using UnityEngine;

namespace Objects
{
    public class Arrow : MonoBehaviour
    {
        private float projectileSpeed;
        private float projectileDamage;
        private Rigidbody2D rb;
        private float range;
        private Vector3 startingPosition;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            projectileSpeed = new TrapsDatabaseConn("Cannon").GETTrapProjectileSpeed();
            projectileDamage = new TrapsDatabaseConn("Cannon").GETTrapDamage();
            range = new TrapsDatabaseConn("Cannon").GETTrapRange();
            rb.velocity = rb.velocity = transform.up * projectileSpeed;
            startingPosition = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(startingPosition, transform.position) > range)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(projectileDamage);
                Destroy(gameObject);
            }
        }
    }
}