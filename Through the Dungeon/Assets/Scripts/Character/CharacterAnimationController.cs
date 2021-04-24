using System;
using Combat.Enemy;
using Combat.Player;
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
        private Animator characterGfx;

        public void Awake()
        {
            characterGfx = GetComponent<Animator>();
        }

        public string GetCurrentAnimation()
        {
            return characterGfx.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        }

        public void ChangeDirection(Direction direction){
            switch (direction)
            {
                case Direction.Down:
                    horizontalSpeed = 0f;
                    verticalSpeed = -1f;
                    isIdle = false;
                    break;
                case Direction.Up:
                    horizontalSpeed = 0f;
                    verticalSpeed = 1f;
                    isIdle = false;
                    break;
                case Direction.Right:
                    horizontalSpeed = 1f;
                    verticalSpeed = 0f;
                    isIdle = false;
                    break;
                case Direction.Left:
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
        
        
            characterGfx.SetFloat("HorizontalSpeed", horizontalSpeed);
            characterGfx.SetFloat("VerticalSpeed", verticalSpeed);
            characterGfx.SetBool("isIdle", isIdle);
        }

        public void CharacterSwim(bool isSwimming)
        {
            characterGfx.SetBool("isSwimming", isSwimming);
        }

        public void StartAttack()
        {
            characterGfx.SetTrigger("Attack");
        }

        public void StartFireAttack()
        {
            characterGfx.SetTrigger("FireAttack");
        }

        public void StartRangedAttack()
        {
            characterGfx.SetTrigger("RangedAttack");
        }

        public void StartDefensiveAbility()
        {
            characterGfx.SetTrigger("DefensiveAbility");
        }

        public void StartHealingAbility()
        {
            characterGfx.SetTrigger("HealingAbility");
        }

        public void TakeHit()
        {
            characterGfx.SetTrigger("Hit");
        }

        public void CharacterDeath()
        {
            characterGfx.SetTrigger("Death");
        }

        public void ApplyDamageToEnemy()
        {
            transform.parent.gameObject.GetComponentInChildren<PlayerAttackController>().ApplyDamage("BasicAttack");
        }

        public void ApplyFireDamageToEnemy()
        {
            transform.parent.gameObject.GetComponentInChildren<PlayerAttackController>().ApplyDamage("FireAttack");
        }

        public void ApplyDamageToPlayer()
        {
            transform.parent.gameObject.GetComponentInChildren<EnemyAttackController>().ApplyDamage();
        }

        public void HealPlayer()
        {
            transform.parent.gameObject.GetComponent<PlayerController>().HealPlayer();
        }

        public void FreezePlayerPosition()
        {
            GetComponentInParent<PlayerController>().FreezePosition();
        }
        
        public void FreezeEnemyPosition()
        {
            GetComponentInParent<EnemyController>().FreezePosition();
        }
        
        public void FreezeEnemyBossPosition()
        {
            GetComponentInParent<DeathBossController>().FreezePosition();
        }

        public void UnfreezePlayerPosition()
        {
            GetComponentInParent<PlayerController>().UnfreezePosition();
        }
        
        public void UnfreezeEnemyPosition()
        {
            GetComponentInParent<EnemyController>().UnfreezePosition();
        }
        
        public void UnfreezeEnemyBossPosition()
        {
            GetComponentInParent<DeathBossController>().UnfreezePosition();
        }

        public void ResetScale()
        {
            GetComponentInParent<EnemyController>().ResetScale();
        }

        public void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }

        public void DestroyBoss()
        {
            transform.parent.gameObject.GetComponent<DeathBossController>().Death();
        }

        public void BossAttack(string trigger)
        {
            characterGfx.SetTrigger(trigger);
        }

        public void Summon()
        {
            GetComponentInParent<DeathBossController>().Summon();
        }
    }
}
