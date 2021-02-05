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

        private void Awake()
        {
            m_Rb = GetComponent<Rigidbody2D>();
            m_ProjectileSpeed = new TrapsDatabaseConn("Cannon").GETTrapProjectileSpeed();
            m_ProjectileDamage = new TrapsDatabaseConn("Cannon").GETTrapDamage();
            m_Rb.velocity = m_Rb.velocity = transform.up * m_ProjectileSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(m_ProjectileDamage);
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "Object")
            {
                Destroy(gameObject);
            }
        }
    }
}