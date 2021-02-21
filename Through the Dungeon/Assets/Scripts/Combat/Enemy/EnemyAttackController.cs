using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private CharacterAnimationController m_CharacterAnimationController;
    private float m_BasicAttackDamage = 0f;
    
    void Awake()
    {
        m_CharacterAnimationController = transform.parent.gameObject.GetComponentInChildren<CharacterAnimationController>();
    }

    public void Attack()
    {
        m_CharacterAnimationController.StartAttack();
    }
    
    public void ApplyDamage()
    {
        GetComponentInChildren<EnemyBasicAttack>().Attack(m_BasicAttackDamage);
    }
    
    public void SetAttackRange(float attackRange)
    {
        GetComponentInChildren<EnemyBasicAttack>().SetAttackRange(attackRange);
    }

    public void SetBasicAttackDamage(float attackDamage)
    {
        m_BasicAttackDamage = attackDamage;
    }
}
