using DatabasesScripts;
using UnityEngine;

namespace Abilities
{
    public class DefensiveAbility : Ability
    {
        private float damageReduction;
        private float abilityDuration;
        
        public DefensiveAbility(AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            damageReduction = dbConn.getAbilityDamageReduction();
            abilityDuration = dbConn.getAbilityDuration();
        }
        
        public override void startAbility()
        {
            isActive = true;
            characterGFX.startDefensiveAbility();
        }

        public void disableAbillity()
        {
            isActive = false;
        }

        public override bool isAbilityActive()
        {
            return isActive;
        }

        public float getDamageReduction()
        {
            return damageReduction;
        }

        public float getAbilityDuration()
        {
            return abilityDuration;
        }
    }
}