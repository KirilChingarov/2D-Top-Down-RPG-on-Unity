using Player;
using UnityEngine;

namespace Combat.Enemy
{
    public class EnemyBasicAttack : MonoBehaviour
    {
        private GameObject player;
        private bool inRange = false;

        void Start()
        {
            player = GameObject.Find("PlayerCharacter");
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                inRange = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                inRange = false;
            }
        }

        public void Attack(float attackDamage)
        {
            if (inRange)
            {
                player.GetComponent<PlayerController>().TakeDamage(attackDamage);
            }
        }

        public void SetAttackRange(float attackRange)
        {
            GetComponent<CircleCollider2D>().radius = attackRange;
        }
    }
}
