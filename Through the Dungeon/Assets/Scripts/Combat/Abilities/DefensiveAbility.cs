using DatabasesScripts;

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
            throw new System.NotImplementedException();
        }

        public override bool isAbilityActive()
        {
            throw new System.NotImplementedException();
        }
    }
}