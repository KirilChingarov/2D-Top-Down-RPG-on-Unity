using DatabasesScripts;

namespace Abilities
{
    public class HealingAbility : Ability
    {
        private float healAmount;
        
        public HealingAbility(AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            healAmount = dbConn.getAbilityHealingAmount();
        }

        public override void startAbility()
        {
            characterGFX.startHealingAbility();
        }

        public override bool isAbilityActive()
        {
            return false;
        }

        public float getHealingAmount()
        {
            return healAmount;
        }
    }
}