using UnityEngine;

namespace Enemy
{
    public class AggroRange : MonoBehaviour
    {
        private Collider2D collider;
        private bool isPlayerInAggroRange = false;
    
        void Start()
        {
            collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                isPlayerInAggroRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                isPlayerInAggroRange = false;
            }
        }

        public bool IsPlayerInAggroRange()
        {
            return isPlayerInAggroRange;
        }
    }
}
