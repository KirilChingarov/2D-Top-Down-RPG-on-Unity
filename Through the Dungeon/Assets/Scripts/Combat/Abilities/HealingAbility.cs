using DatabasesScripts;

namespace Combat.Abilities
{
    public class HealingAbility : Ability
    {
        private float healAmount;
        
        public HealingAbility(AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            healAmount = dbConn.GETAbilityHealingAmount();
        }

        public override void StartAbility()
        {
            CharacterGfx.StartHealingAbility();
        }

        public override bool IsAbilityActive()
        {
            return false;
        }

        public void BuffHealingAmount(float amount)
        {
            healAmount += amount;
        }

        public void setHealingAmount(float amount)
        {
            healAmount = amount;
        }
        
        public float GETHealingAmount()
        {
            return healAmount;
        }
    }
}