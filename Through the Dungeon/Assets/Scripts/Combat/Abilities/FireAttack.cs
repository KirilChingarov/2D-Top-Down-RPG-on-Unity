using UnityEngine;
using Abilities;
using Character;
using DatabasesScripts;

namespace Abilities
{
    public class FireAttack : Ability
    {
        private GameObject attackObject;
        
        public FireAttack(string abilityName, float cooldown, string keyCode, GameObject attackObject, AbilitiesDatabaseConn dbConn) : base(abilityName, cooldown, keyCode)
        {
            this.attackObject = attackObject;
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