using System;
using Enemy;
using UnityEngine;
using Enums;
using Player;

namespace Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        private bool isIdle = true;
        private Animator characterGFX;

        public void Awake()
        {
            characterGFX = GetComponent<Animator>();
        }

        public void changeDirection(Direction direction){
            switch (direction)
            {
                case Direction.DOWN:
                    horizontalSpeed = 0f;
                    verticalSpeed = -1f;
                    isIdle = false;
                    break;
                case Direction.UP:
                    horizontalSpeed = 0f;
                    verticalSpeed = 1f;
                    isIdle = false;
                    break;
                case Direction.RIGHT:
                    horizontalSpeed = 1f;
                    verticalSpeed = 0f;
                    isIdle = false;
                    break;
                case Direction.LEFT:
                    horizontalSpeed = -1f;
                    verticalSpeed = 0f;
                    isIdle = false;
                    break;
                default:
                    horizontalSpeed = 0f;
                    verticalSpeed = 0f;
                    isIdle = true;
                    break;
            }
        
        
            characterGFX.SetFloat("HorizontalSpeed", horizontalSpeed);
            characterGFX.SetFloat("VerticalSpeed", verticalSpeed);
            characterGFX.SetBool("isIdle", isIdle);
        }

        public void startAttack()
        {
            characterGFX.SetTrigger("Attack");
        }

        public void startFireAttack()
        {
            characterGFX.SetTrigger("FireAttack");
        }

        public void startRangedAttack()
        {
            characterGFX.SetTrigger("RangedAttack");
        }

        public void startDefensiveAbility()
        {
            characterGFX.SetTrigger("DefensiveAbility");
        }

        public void startHealingAbility()
        {
            characterGFX.SetTrigger("HealingAbility");
        }

        public void applyDamageToEnemy()
        {
            transform.parent.gameObject.GetComponentInChildren<PlayerAttackController>().applyDamage("BasicAttack");
        }

        public void applyFireDamageToEnemy()
        {
            transform.parent.gameObject.GetComponentInChildren<PlayerAttackController>().applyDamage("FireAttack");
        }

        public void applyDamageToPlayer()
        {
            transform.parent.gameObject.GetComponentInChildren<EnemyAttackController>().applyDamage();
        }

        public void healPlayer()
        {
            transform.parent.gameObject.GetComponent<PlayerController>().healPlayer();
        }

        public void freezePlayerPosition()
        {
            GetComponentInParent<PlayerController>().freezePosition();
        }
        
        public void freezeEnemyPosition()
        {
            GetComponentInParent<EnemyController>().freezePosition();
        }

        public void unfreezePlayerPosition()
        {
            GetComponentInParent<PlayerController>().unfreezePosition();
        }
        
        public void unfreezeEnemyPosition()
        {
            GetComponentInParent<EnemyController>().unfreezePosition();
        }
    }
}
