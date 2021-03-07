using UnityEngine;

namespace Enemy
{
    public class PlayerHitCheckBoxBoss : MonoBehaviour
    {
        private DeathBossController m_EnemyController;
        
        void Awake()
        {
            m_EnemyController = GetComponentInParent<DeathBossController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "PlayerCharacter")
            {
                m_EnemyController.SetReachedEndOfPath(true);
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name == "PlayerCharacter")
            {
                m_EnemyController.SetReachedEndOfPath(false);
            }
        }
    }
}