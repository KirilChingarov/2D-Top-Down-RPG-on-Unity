using DatabasesScripts;
using UnityEngine;

namespace Combat.Abilities
{
    public class FireAttack : Ability
    {
        private GameObject attackObject;
        private float attackDamage = 0f;

        public FireAttack(GameObject attackObject, AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            this.attackObject = attackObject;

            attackDamage = this.DBConn.GETAbilityAttackDamage();
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
            attackDamage += damage;
        }

        public void setAttackDamage(float damage)
        {
            attackDamage = damage;
        }
        
        public float GETFireAttackDamage()
        {
            return attackDamage;
        }
    }
}