using System.Collections;
using System.Collections.Generic;
using Character;
using Player;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private CharacterAnimationController characterAnimationController;
    private CircleCollider2D basicAttackRange;
    private float basicAttackDamage = 0f;
    
    void Awake()
    {
        characterAnimationController = GameObject.Find("CharacterGFX").GetComponent<CharacterAnimationController>();
        basicAttackRange = this.transform.Find("BasicAttack").GetComponent<CircleCollider2D>();
    }

    public void Attack()
    {
        characterAnimationController.attack();
        GetComponentInChildren<BasicAttack>().attack(basicAttackDamage);
    }

    public void setAttackRange(float attackRange)
    {
        basicAttackRange.radius = attackRange;
    }

    public void setBasicAttackDamage(float attackDamage)
    {
        basicAttackDamage = attackDamage;
    }
}
