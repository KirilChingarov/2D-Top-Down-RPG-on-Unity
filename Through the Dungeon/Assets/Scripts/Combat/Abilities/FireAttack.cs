using UnityEngine;
using Abilities;
using Character;
using DatabasesScripts;

namespace Abilities
{
    public class FireAttack : Ability
    {
        private GameObject m_AttackObject;
        private float m_AttackDamage = 0f;

        public FireAttack(GameObject attackObject, AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            m_AttackObject = attackObject;

            m_AttackDamage = this.DBConn.GETAbilityAttackDamage();
            float attackRange = dbConn.GETAbilityAttackRange();
            attackObject.GetComponent<CircleCollider2D>().radius = attackRange;
        }

        public override void StartAbility()
        {
            CharacterGfx.StartFireAttack();
        }

        public override bool IsAbilityActive()
        {
            return IsActive;
        }

        public void BuffAttackDamage(float damage)
        {
            m_AttackDamage += damage;
        }
        
        public float GETFireAttackDamage()
        {
            return m_AttackDamage;
        }
    }
}