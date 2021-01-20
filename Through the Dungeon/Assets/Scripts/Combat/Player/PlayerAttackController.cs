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
            new AbilitiesDatabaseConn("Abilities.db", "FireAttack"));
        fireAttack.setCharacterAnimationController(characterAnimationController);
    }

    public void FireAttack()
    {
        fireAttack.startAbility();
    }
    
    public string getFireAttackKeyCode()
    {
        return fireAttack.getKeyCode();
    }

    public float getFireAttackCooldown()
    {
        return fireAttack.getCooldown();
    }
}
