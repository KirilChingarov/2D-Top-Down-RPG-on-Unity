using UnityEngine;

namespace Enemy
{
    public class PlayerHitCheckBoxBoss : MonoBehaviour
    {
        private DeathBossController enemyController;
        
        void Awake()
        {
            enemyController = GetComponentInParent<DeathBossController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "PlayerCharacter")
            {
                enemyController.SetReachedEndOfPath(true);
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name == "PlayerCharacter")
            {
                enemyController.SetReachedEndOfPath(false);
            }
        }
    }
}