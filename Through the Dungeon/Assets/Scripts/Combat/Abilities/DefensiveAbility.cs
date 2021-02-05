using DatabasesScripts;
using UnityEngine;

namespace Abilities
{
    public class DefensiveAbility : Ability
    {
        private float m_DamageReduction;
        private float m_AbilityDuration;
        
        public DefensiveAbility(AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            m_DamageReduction = dbConn.GETAbilityDamageReduction();
            m_AbilityDuration = dbConn.GETAbilityDuration();
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
            m_DamageReduction += amount;
        }
        
        public float GETDamageReduction()
        {
            return m_DamageReduction;
        }

        public float GETAbilityDuration()
        {
            return m_AbilityDuration;
        }
    }
}