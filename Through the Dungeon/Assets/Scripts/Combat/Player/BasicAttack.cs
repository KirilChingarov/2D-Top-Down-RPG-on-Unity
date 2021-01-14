using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    private List<bool> inRange = new List<bool>();

    public void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        for (int i = 0; i < enemies.Count; i++)
        {
            inRange.Add(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange[enemies.IndexOf(other.gameObject)] = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange[enemies.IndexOf(other.gameObject)] = false;
        }
    }

    public void attack(float attackDamage)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (inRange[i])
            {
                enemies[i].GetComponent<EnemyController>().takeDamage(attackDamage);
            }
        }
    }

    public void setAttackRange(float attackRange)
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
    }
}
