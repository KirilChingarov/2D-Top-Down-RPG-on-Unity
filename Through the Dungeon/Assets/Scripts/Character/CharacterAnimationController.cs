using System;
using Enemy;
using UnityEngine;
using Enums;
using Player;

namespace Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private float m_HorizontalSpeed = 0f;
        private float m_VerticalSpeed = 0f;
        private bool m_IsIdle = true;
        private Animator m_CharacterGfx;

        public void Awake()
        {
            m_CharacterGfx = GetComponent<Animator>();
        }

        public void ChangeDirection(Direction direction){
            switch (direction)
            {
                case Direction.Down:
                    m_HorizontalSpeed = 0f;
                    m_VerticalSpeed = -1f;
                    m_IsIdle = false;
                    break;
                case Direction.Up:
                    m_HorizontalSpeed = 0f;
                    m_VerticalSpeed = 1f;
                    m_IsIdle = false;
                    break;
                case Direction.Right:
                    m_HorizontalSpeed = 1f;
                    m_VerticalSpeed = 0f;
                    m_IsIdle = false;
                    break;
                case Direction.Left:
                    m_HorizontalSpeed = -1f;
                    m_VerticalSpeed = 0f;
                    m_IsIdle = false;
                    break;
                default:
                    m_HorizontalSpeed = 0f;
                    m_VerticalSpeed = 0f;
                    m_IsIdle = true;
                    break;
            }
        
        
            m_CharacterGfx.SetFloat("HorizontalSpeed", m_HorizontalSpeed);
            m_CharacterGfx.SetFloat("VerticalSpeed", m_VerticalSpeed);
            m_CharacterGfx.SetBool("isIdle", m_IsIdle);
        }

        public void CharacterSwim(bool isSwimming)
        {
            m_CharacterGfx.SetBool("isSwimming", isSwimming);
        }

        public void StartAttack()
        {
            m_CharacterGfx.SetTrigger("Attack");
        }

        public void StartFireAttack()
        {
            m_CharacterGfx.SetTrigger("FireAttack");
        }

        public void StartRangedAttack()
        {
            m_CharacterGfx.SetTrigger("RangedAttack");
        }

        public void StartDefensiveAbility()
        {
            m_CharacterGfx.SetTrigger("DefensiveAbility");
        }

        public void StartHealingAbility()
        {
            m_CharacterGfx.SetTrigger("HealingAbility");
        }

        public void TakeHit()
        {
            m_CharacterGfx.SetTrigger("Hit");
        }

        public void CharacterDeath()
        {
            m_CharacterGfx.SetTrigger("Death");
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
            GetComponentInParent<DeathBossController>().FreezePosition();
        }

        public void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }

        public void BossAttack(string trigger)
        {
            m_CharacterGfx.SetTrigger(trigger);
        }

        public void Summon()
        {
            GetComponentInParent<DeathBossController>().Summon();
        }
    }
}
