using System;
using System.Collections;
using System.Collections.Generic;
using DatabasesScripts;
using Enemy;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private List<EnemyController> enemies;
    private List<bool> inRange = new List<bool> {false};


    public void Start()
    {
        throw new NotImplementedException();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with " + other.gameObject.name);
            EnemyController newEnemy = other.gameObject.GetComponent<EnemyController>() as EnemyController;
            enemies.Add(newEnemy);
            inRange.Add(true);
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int enemyIndex = enemies.IndexOf(other.gameObject.GetComponent<EnemyController>());
            enemies.RemoveAt(enemyIndex);
            inRange.RemoveAt(enemyIndex);
        }
    }

    public void attack(float attackDamage)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].takeDamage(attackDamage);
        }
    }
}
