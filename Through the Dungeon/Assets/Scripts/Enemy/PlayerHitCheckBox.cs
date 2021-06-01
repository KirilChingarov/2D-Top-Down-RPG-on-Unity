using UnityEngine;

namespace Enemy
{
    public class PlayerHitCheckBox : MonoBehaviour
    {
        private EnemyController enemyController;
    
        void Awake()
        {
            enemyController = GetComponentInParent<EnemyController>();
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
