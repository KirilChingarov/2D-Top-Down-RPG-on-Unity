using System.Collections;
using System.Collections.Generic;
using Abilities;
using Character;
using DatabasesScripts;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private CharacterAnimationController characterAnimationController;
    private float basicAttackDamage = 0f;
    private FireAttack fireAttack;
    private RangedAttack rangedAttack;
    private DefensiveAbility defensiveAbility;
    private HealingAbility healingAbility;
    
    void Awake()
    {
        characterAnimationController = transform.parent.gameObject.GetComponentInChildren<CharacterAnimationController>();
    }

    public void Attack()
    {
        characterAnimationController.startAttack();
    }

    public void applyDamage(string gameObjectName)
    {
        float damage;
        switch (gameObjectName)
        {
            case "BasicAttack":
                damage = basicAttackDamage;
                break;
            case "FireAttack":
                damage = fireAttack.getFireAttackDamage();
                break;
            default:
                damage = 0f;
                break;
        }
        
        transform.Find(gameObjectName).GetComponent<AttackHitbox>().attack(damage);
    }

    public void setAttackRange(float attackRange)
    {
        GetComponentInChildren<AttackHitbox>().setAttackRange(attackRange);
    }

    public void setBasicAttackDamage(float attackDamage)
    {
        basicAttackDamage = attackDamage;
    }

    public void setUpFireAttack()
    {
        fireAttack = new FireAttack(GameObject.Find("FireAttack"), 
            new AbilitiesDatabaseConn("FireAttack"));
        fireAttack.setCharacterAnimationController(characterAnimationController);
    }

    public void FireAttack()
    {
        fireAttack.startAbility();
        GameObject.Find("FireAttack").GetComponent<FireAttackAnimation>().triggerFireVFX();
    }
    
    public string getFireAttackKeyCode()
    {
        return fireAttack.getKeyCode();
    }

    public float getFireAttackCooldown()
    {
        return fireAttack.getCooldown();
    }

    public void setUpRangedAttack()
    {
        rangedAttack = new RangedAttack(GameObject.Find("RangedAttack").transform,
            Resources.Load("Prefabs/VFX/WindSlash") as GameObject, 
            new AbilitiesDatabaseConn("RangedAttack"));
        rangedAttack.setCharacterAnimationController(characterAnimationController);
    }

    public void RangedAttack()
    {
        rangedAttack.startAbility();
    }

    public string getRangedAttackKeyCode()
    {
        return rangedAttack.getKeyCode();
    }

    public float getRangedAttackCooldown()
    {
        return rangedAttack.getCooldown();
    }

    public void setUpDefensiveAbility()
    {
        defensiveAbility = new DefensiveAbility(new AbilitiesDatabaseConn("DefensiveAbility"));
        defensiveAbility.setCharacterAnimationController(characterAnimationController);
    }

    public void DefensiveAbility()
    {
        defensiveAbility.startAbility();
        Invoke("disableDefensiveAbility", defensiveAbility.getAbilityDuration());
    }

    private void disableDefensiveAbility()
    {
        defensiveAbility.disableAbillity();
    }

    public bool isDefensiveAbilityActive()
    {
        return defensiveAbility.isAbilityActive();
    }

    public float getDefensiveAbilityDmgReduction()
    {
        return defensiveAbility.getDamageReduction();
    }

    public string getDefensiveAbilityKeyCode()
    {
        return defensiveAbility.getKeyCode();
    }

    public float getDefensiveAbilityCooldown()
    {
        return defensiveAbility.getCooldown();
    }

    public void setUpHealingAbility()
    {
        healingAbility = new HealingAbility(new AbilitiesDatabaseConn("HealingAbility"));
        healingAbility.setCharacterAnimationController(characterAnimationController);
    }

    public void Heal()
    {
        healingAbility.startAbility();
    }

    public string getHealingAbilityKeyCode()
    {
        return healingAbility.getKeyCode();
    }

    public float getHealingAbilityCooldown()
    {
        return healingAbility.getCooldown();
    }

    public float getHealingAmount()
    {
        return healingAbility.getHealingAmount();
    }
}
