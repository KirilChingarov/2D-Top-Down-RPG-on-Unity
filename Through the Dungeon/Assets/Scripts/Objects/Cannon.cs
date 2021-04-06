using System;
using DatabasesScripts;
using UnityEngine;

namespace Objects
{
    public class Cannon : MonoBehaviour
    {
        private GameObject projectile;
        private Transform firePoint;

        private void Awake()
        {
            projectile = Resources.Load("Prefabs/Traps/Arrow") as GameObject;
            firePoint = transform.Find("FirePoint").GetComponent<Transform>();
            
            InvokeRepeating("Shoot", 3f, new TrapsDatabaseConn("Cannon").GETTrapCooldown());
        }

        private void Shoot()
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
    }
}