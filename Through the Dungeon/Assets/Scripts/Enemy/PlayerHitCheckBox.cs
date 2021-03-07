using Enemy;
using UnityEngine;

public class PlayerHitCheckBox : MonoBehaviour
{
    private EnemyController m_EnemyController;
    
    void Awake()
    {
        m_EnemyController = GetComponentInParent<EnemyController>();
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
