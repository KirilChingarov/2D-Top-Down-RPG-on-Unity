using System;
using DatabasesScripts;
using Player;
using UnityEngine;

namespace Objects
{
    public class Arrow : MonoBehaviour
    {
        private float m_ProjectileSpeed;
        private float m_ProjectileDamage;
        private Rigidbody2D m_Rb;
        private float m_Range;
        private Vector3 startingPosition;

        private void Awake()
        {
            m_Rb = GetComponent<Rigidbody2D>();
            m_ProjectileSpeed = new TrapsDatabaseConn("Cannon").GETTrapProjectileSpeed();
            m_ProjectileDamage = new TrapsDatabaseConn("Cannon").GETTrapDamage();
            m_Range = new TrapsDatabaseConn("Cannon").GETTrapRange();
            m_Rb.velocity = m_Rb.velocity = transform.up * m_ProjectileSpeed;
            startingPosition = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(startingPosition, transform.position) > m_Range)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(m_ProjectileDamage);
                Destroy(gameObject);
            }
        }
    }
}