using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Combat.Player
{
    public class AttackHitbox : MonoBehaviour
    {
        private List<GameObject> m_Enemies = new List<GameObject>();
        private List<bool> m_InRange = new List<bool>();

        public void Start()
        {
            m_Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
            for (int i = 0; i < m_Enemies.Count; i++)
            {
                m_InRange.Add(false);
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (!m_Enemies.Contains(other.gameObject))
                {
                    m_Enemies.Add(other.gameObject);
                    m_InRange.Add(true);
                }
                else m_InRange[m_Enemies.IndexOf(other.gameObject)] = true;
            }
        }
    
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                m_InRange[m_Enemies.IndexOf(other.gameObject)] = false;
            }
        }

        public void Attack(float attackDamage)
        {
            for (int i = 0; i < m_Enemies.Count; i++)
            {
                if (m_InRange[i])
                {
                    if(m_Enemies[i].GetComponent<EnemyController>() != null) m_Enemies[i].GetComponent<EnemyController>().TakeDamage(attackDamage);
                    else m_Enemies[i].GetComponent<DeathBossController>().TakeDamage(attackDamage);
                }
            }
        }

        public void SetAttackRange(float attackRange)
        {
            GetComponent<CircleCollider2D>().radius = attackRange;
        }
    }
}
