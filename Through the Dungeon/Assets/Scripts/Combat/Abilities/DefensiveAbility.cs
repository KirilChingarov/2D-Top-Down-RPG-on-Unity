using DatabasesScripts;

namespace Combat.Abilities
{
    public class DefensiveAbility : Ability
    {
        private float damageReduction;
        private float abilityDuration;
        
        public DefensiveAbility(AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            damageReduction = dbConn.GETAbilityDamageReduction();
            abilityDuration = dbConn.GETAbilityDuration();
        }
        
        public override void StartAbility()
        {
            IsActive = true;
            CharacterGfx.StartDefensiveAbility();
        }

        public void DisableAbillity()
        {
            IsActive = false;
        }

        public override bool IsAbilityActive()
        {
            return IsActive;
        }

        public void BuffDamageReduction(float amount)
        {
            damageReduction += amount;
        }

        public void setDamageReduction(float damageReduction)
        {
            this.damageReduction = damageReduction;
        }
        
        public float GETDamageReduction()
        {
            return damageReduction;
        }

        public float GETAbilityDuration()
        {
            return abilityDuration;
        }
    }
}