using UnityEngine;
using Abilities;
using Character;
using DatabasesScripts;

namespace Abilities
{
    public class FireAttack : Ability
    {
        private GameObject attackObject;
        private float attackDamage = 0f;

        public FireAttack(GameObject attackObject, AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            this.attackObject = attackObject;

            attackDamage = this.dbConn.getAbilityAttackDamage();
            float attackRange = dbConn.getAbilityAttackRange();
            attackObject.GetComponent<CircleCollider2D>().radius = attackRange;
        }

        public override void startAbility()
        {
            Debug.Log("Starting Fire Ability");
            characterGFX.startFireAttack();
        }

        public override bool isAbilityActive()
        {
            return isActive;
        }

        public void setCharacterAnimationController(CharacterAnimationController characterGFX)
        {
            this.characterGFX = characterGFX;
        }

        public float getFireAttackDamage()
        {
            return attackDamage;
        }
    }
}