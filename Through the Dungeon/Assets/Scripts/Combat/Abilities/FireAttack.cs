using UnityEngine;
using Abilities;
using Character;
using DatabasesScripts;

namespace Abilities
{
    public class FireAttack : Ability
    {
        private GameObject attackObject;
        private AbilitiesDatabaseConn dbConn;
        
        
        public FireAttack(GameObject attackObject, AbilitiesDatabaseConn dbConn) : base()
        {
            this.attackObject = attackObject;
            this.dbConn = dbConn;
            abilityName = this.dbConn.getAbiltyName();
            cooldown = this.dbConn.getAbilityCooldown();
            keyCode = this.dbConn.getAbilityKeyCode();
            abilityType = this.dbConn.getAbilityType();
            isActive = false;
        }

        public override void startAbility()
        {
            throw new System.NotImplementedException();
        }

        public override bool isAbilityActive()
        {
            return isActive;
        }

        public void setCharacterAnimationController(CharacterAnimationController characterGFX)
        {
            this.characterGFX = characterGFX;
        }
    }
}