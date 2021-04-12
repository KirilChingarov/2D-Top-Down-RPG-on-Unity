using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Combat.Player
{
    public class AttackHitbox : MonoBehaviour
    {
        private List<GameObject> enemies = new List<GameObject>();
        private List<bool> inRange = new List<bool>();

        public void Start()
        {
            enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
            for (int i = 0; i < enemies.Count; i++)
            {
                inRange.Add(false);
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (!enemies.Contains(other.gameObject))
                {
                    enemies.Add(other.gameObject);
                    inRange.Add(true);
                }
                else inRange[enemies.IndexOf(other.gameObject)] = true;
            }
        }
    
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                inRange[enemies.IndexOf(other.gameObject)] = false;
            }
        }

        public void Attack(float attackDamage)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (inRange[i])
                {
                    if(enemies[i].GetComponent<EnemyController>() != null) enemies[i].GetComponent<EnemyController>().TakeDamage(attackDamage);
                    else enemies[i].GetComponent<DeathBossController>().TakeDamage(attackDamage);
                }
            }
        }

        public void SetAttackRange(float attackRange)
        {
            GetComponent<CircleCollider2D>().radius = attackRange;
        }
    }
}
