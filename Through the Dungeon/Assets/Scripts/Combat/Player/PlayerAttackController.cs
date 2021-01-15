using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
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
        GetComponentInChildren<BasicAttack>().attack(basicAttackDamage);
    }

    public void setAttackRange(float attackRange)
    {
        GetComponentInChildren<BasicAttack>().setAttackRange(attackRange);
    }

    public void setBasicAttackDamage(float attackDamage)
    {
        basicAttackDamage = attackDamage;
    }
}
