using System;
using DatabasesScripts;
using UnityEngine;

namespace Objects
{
    public class Cannon : MonoBehaviour
    {
        private GameObject m_Projectile;
        private Transform m_FirePoint;

        private void Awake()
        {
            m_Projectile = Resources.Load("Prefabs/Traps/Arrow") as GameObject;
            m_FirePoint = transform.Find("FirePoint").GetComponent<Transform>();
            
            InvokeRepeating("Shoot", 3f, new TrapsDatabaseConn("Cannon").GETTrapCooldown());
        }

        private void Shoot()
        {
            Instantiate(m_Projectile, m_FirePoint.position, m_FirePoint.rotation);
        }
    }
}