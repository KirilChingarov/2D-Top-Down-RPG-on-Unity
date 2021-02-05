using System.Collections;
using System.Collections.Generic;
using Abilities;
using Character;
using DatabasesScripts;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private CharacterAnimationController m_CharacterAnimationController;
    private float m_BasicAttackDamage = 0f;
    private FireAttack m_FireAttack;
    private RangedAttack m_RangedAttack;
    private DefensiveAbility m_DefensiveAbility;
    private HealingAbility m_HealingAbility;
    
    void Awake()
    {
        m_CharacterAnimationController = transform.parent.gameObject.GetComponentInChildren<CharacterAnimationController>();
    }

    public void Attack()
    {
        m_CharacterAnimationController.StartAttack();
    }

    public void ApplyDamage(string gameObjectName)
    {
        float damage;
        switch (gameObjectName)
        {
            case "BasicAttack":
                damage = m_BasicAttackDamage;
                break;
            case "FireAttack":
                damage = m_FireAttack.GETFireAttackDamage();
                break;
            default:
                damage = 0f;
                break;
        }
        
        transform.Find(gameObjectName).GetComponent<AttackHitbox>().Attack(damage);
    }

    public void SetAttackRange(float attackRange)
    {
        GetComponentInChildren<AttackHitbox>().SetAttackRange(attackRange);
    }

    public void SetBasicAttackDamage(float attackDamage)
    {
        m_BasicAttackDamage = attackDamage;
    }

    public void SetUpFireAttack()
    {
        m_FireAttack = new FireAttack(GameObject.Find("FireAttack"), 
            new AbilitiesDatabaseConn("FireAttack"));
        m_FireAttack.SetCharacterAnimationController(m_CharacterAnimationController);
    }

    public void FireAttack()
    {
        m_FireAttack.StartAbility();
        GameObject.Find("FireAttack").GetComponent<FireAttackAnimation>().TriggerFireVFX();
    }

    public void BuffFireAttackDamage(float damage)
    {
        m_FireAttack.BuffAttackDamage(damage);
    }
    
    public string GETFireAttackKeyCode()
    {
        return m_FireAttack.GETKeyCode();
    }

    public float GETFireAttackCooldown()
    {
        return m_FireAttack.GETCooldown();
    }

    public void SetUpRangedAttack()
    {
        m_RangedAttack = new RangedAttack(GameObject.Find("RangedAttack").transform,
            Resources.Load("Prefabs/VFX/WindSlash") as GameObject, 
            new AbilitiesDatabaseConn("RangedAttack"));
        m_RangedAttack.SetCharacterAnimationController(m_CharacterAnimationController);
    }

    public void RangedAttack()
    {
        m_RangedAttack.StartAbility();
    }

    public void BuffRangedAttackDamage(float damage)
    {
        m_RangedAttack.BuffRangedAttackDamage(damage);
    }

    public string GETRangedAttackKeyCode()
    {
        return m_RangedAttack.GETKeyCode();
    }

    public float GETRangedAttackCooldown()
    {
        return m_RangedAttack.GETCooldown();
    }

    public void SetUpDefensiveAbility()
    {
        m_DefensiveAbility = new DefensiveAbility(new AbilitiesDatabaseConn("DefensiveAbility"));
        m_DefensiveAbility.SetCharacterAnimationController(m_CharacterAnimationController);
    }

    public void DefensiveAbility()
    {
        m_DefensiveAbility.StartAbility();
        Invoke("DisableDefensiveAbility", m_DefensiveAbility.GETAbilityDuration());
    }

    private void DisableDefensiveAbility()
    {
        m_DefensiveAbility.DisableAbillity();
    }

    public bool IsDefensiveAbilityActive()
    {
        return m_DefensiveAbility.IsAbilityActive();
    }

    public void BuffDefensiveDamageReduction(float amount)
    {
        m_DefensiveAbility.BuffDamageReduction(amount);
    }

    public float GETDefensiveAbilityDmgReduction()
    {
        return m_DefensiveAbility.GETDamageReduction();
    }

    public string GETDefensiveAbilityKeyCode()
    {
        return m_DefensiveAbility.GETKeyCode();
    }

    public float GETDefensiveAbilityCooldown()
    {
        return m_DefensiveAbility.GETCooldown();
    }

    public void SetUpHealingAbility()
    {
        m_HealingAbility = new HealingAbility(new AbilitiesDatabaseConn("HealingAbility"));
        m_HealingAbility.SetCharacterAnimationController(m_CharacterAnimationController);
    }

    public void Heal()
    {
        m_HealingAbility.StartAbility();
    }

    public string GETHealingAbilityKeyCode()
    {
        return m_HealingAbility.GETKeyCode();
    }

    public float GETHealingAbilityCooldown()
    {
        return m_HealingAbility.GETCooldown();
    }

    public void BuffHealingAbilityAmount(float amount)
    {
        m_HealingAbility.BuffHealingAmount(amount);
    }

    public float GETHealingAmount()
    {
        return m_HealingAbility.GETHealingAmount();
    }
}
