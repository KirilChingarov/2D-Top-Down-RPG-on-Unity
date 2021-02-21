using DatabasesScripts;

namespace Abilities
{
    public class HealingAbility : Ability
    {
        private float m_HealAmount;
        
        public HealingAbility(AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            m_HealAmount = dbConn.GETAbilityHealingAmount();
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
            m_HealAmount += amount;
        }

        public void setHealingAmount(float amount)
        {
            m_HealAmount = amount;
        }
        
        public float GETHealingAmount()
        {
            return m_HealAmount;
        }
    }
}