using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private CharacterAnimationController characterAnimationController;
    private float basicAttackDamage = 0f;
    
    void Awake()
    {
        characterAnimationController = transform.parent.gameObject.GetComponentInChildren<CharacterAnimationController>();
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
        GetComponentInChildren<EnemyBasicAttack>().setAttackRange(attackRange);
    }

    public void setBasicAttackDamage(float attackDamage)
    {
        basicAttackDamage = attackDamage;
    }
}
