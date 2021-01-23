using System;
using DatabasesScripts;
using UnityEngine;

namespace Traps
{
    public class Cannon : MonoBehaviour
    {
        private GameObject projectile;

        private void Awake()
        {
            projectile = Resources.Load("Prefabs/Traps/Arrow") as GameObject;
            
            InvokeRepeating("Shoot", 3f, new TrapsDatabaseConn("Cannon").getTrapCooldown());
        }

        private void Shoot()
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}