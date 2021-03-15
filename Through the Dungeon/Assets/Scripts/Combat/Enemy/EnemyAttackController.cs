using Character;
using Enums;
using UnityEngine;

namespace Combat.Enemy
{
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

        public string GetCurrentAnimation()
        {
            return m_CharacterAnimationController.GetCurrentAnimation();
        }

        public void BossAttack(DeathBossAttacks attackChoice)
        {
            switch (attackChoice)
            {
                case DeathBossAttacks.Attack_1:
                    m_CharacterAnimationController.BossAttack("Attack_1");
                    break;
                case DeathBossAttacks.Attack_2:
                    m_CharacterAnimationController.BossAttack("Attack_2");
                    break;
                case DeathBossAttacks.Attack_3:
                    m_CharacterAnimationController.BossAttack("Attack_3");
                    break;
                case DeathBossAttacks.Summon:
                    m_CharacterAnimationController.BossAttack("Summon");
                    break;
            }
        }
    }
}
