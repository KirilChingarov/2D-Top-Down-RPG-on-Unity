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

    public void BossAttack(int attackChoice)
    {
        switch (attackChoice)
        {
            case 1:
                m_CharacterAnimationController.BossAttack("Attack_1");
                break;
            case 2:
                m_CharacterAnimationController.BossAttack("Attack_2");
                break;
            case 3:
                m_CharacterAnimationController.BossAttack("Attack_3");
                break;
            case 4:
                m_CharacterAnimationController.BossAttack("Summon");
                break;
        }
    }
}
