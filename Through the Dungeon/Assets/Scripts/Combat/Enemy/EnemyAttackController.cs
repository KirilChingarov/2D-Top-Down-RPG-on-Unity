using Character;
using Enums;
using UnityEngine;

namespace Combat.Enemy
{
    public class EnemyAttackController : MonoBehaviour
    {
        private CharacterAnimationController characterAnimationController;
        private float basicAttackDamage = 0f;
    
        void Awake()
        {
            characterAnimationController = transform.parent.gameObject.GetComponentInChildren<CharacterAnimationController>();
        }

        public void Attack()
        {
            characterAnimationController.StartAttack();
        }
    
        public void ApplyDamage()
        {
            GetComponentInChildren<EnemyBasicAttack>().Attack(basicAttackDamage);
        }
    
        public void SetAttackRange(float attackRange)
        {
            GetComponentInChildren<EnemyBasicAttack>().SetAttackRange(attackRange);
        }

        public void SetBasicAttackDamage(float attackDamage)
        {
            basicAttackDamage = attackDamage;
        }

        public string GetCurrentAnimation()
        {
            return characterAnimationController.GetCurrentAnimation();
        }

        public void BossAttack(DeathBossAttacks attackChoice)
        {
            switch (attackChoice)
            {
                case DeathBossAttacks.Attack_1:
                    characterAnimationController.BossAttack("Attack_1");
                    break;
                case DeathBossAttacks.Attack_2:
                    characterAnimationController.BossAttack("Attack_2");
                    break;
                case DeathBossAttacks.Attack_3:
                    characterAnimationController.BossAttack("Attack_3");
                    break;
                case DeathBossAttacks.Summon:
                    characterAnimationController.BossAttack("Summon");
                    break;
            }
        }
    }
}
