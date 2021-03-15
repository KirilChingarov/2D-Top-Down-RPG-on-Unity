using Player;
using UnityEngine;

namespace Combat.Enemy
{
    public class EnemyBasicAttack : MonoBehaviour
    {
        private GameObject m_Player;
        private bool m_InRange = false;

        void Start()
        {
            m_Player = GameObject.Find("PlayerCharacter");
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                m_InRange = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                m_InRange = false;
            }
        }

        public void Attack(float attackDamage)
        {
            if (m_InRange)
            {
                m_Player.GetComponent<PlayerController>().TakeDamage(attackDamage);
            }
        }

        public void SetAttackRange(float attackRange)
        {
            GetComponent<CircleCollider2D>().radius = attackRange;
        }
    }
}
