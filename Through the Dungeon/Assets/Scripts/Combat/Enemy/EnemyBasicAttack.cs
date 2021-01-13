using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

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

    public void attack(float attackDamage)
    {
        if (inRange)
        {
            player.GetComponent<PlayerController>().takeDamage(attackDamage);
        }
    }
}
