using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

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
            enemyController.setReachedEndOfPath(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerCharacter")
        {
            enemyController.setReachedEndOfPath(false);
        }
    }
}
