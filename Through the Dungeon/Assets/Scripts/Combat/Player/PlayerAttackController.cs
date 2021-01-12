using System.Collections;
using System.Collections.Generic;
using Character;
using Player;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private CharacterAnimationController characterAnimationController;
    private CircleCollider2D basicAttackRange;
    
    void Awake()
    {
        characterAnimationController = GameObject.Find("CharacterGFX").GetComponent<CharacterAnimationController>();
        basicAttackRange = this.transform.Find("BasicAttack").GetComponent<CircleCollider2D>();
    }

    public void Attack()
    {
        characterAnimationController.attack();
    }

    public void setAttackRange(float attackRange)
    {
        basicAttackRange.radius = attackRange;
    }
}
