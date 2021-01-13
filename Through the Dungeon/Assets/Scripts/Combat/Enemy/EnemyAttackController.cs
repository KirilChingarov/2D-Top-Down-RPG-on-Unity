using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private CharacterAnimationController characterAnimationController;
    private CircleCollider2D basicAttackRange;
    private float basicAttackDamage = 0f;
    
    void Awake()
    {
        characterAnimationController = transform.parent.gameObject.GetComponentInChildren<CharacterAnimationController>();
        basicAttackRange = transform.Find("BasicAttack").GetComponent<CircleCollider2D>();
    }

    public void Attack()
    {
        characterAnimationController.startAttack();
    }
    
    public void applyDamage()
    {
        GetComponentInChildren<EnemyBasicAttack>().attack(basicAttackDamage);
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
