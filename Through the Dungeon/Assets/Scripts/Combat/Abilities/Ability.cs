using Character;
using DatabasesScripts;
using Enums;

namespace Abilities
{
    public abstract class Ability
    {
        protected string abilityName;
        protected float cooldown;
        protected string keyCode;
        protected AbilityType abilityType;
        protected bool isActive;
        protected CharacterAnimationController characterGFX;
        protected AbilitiesDatabaseConn dbConn;

        public Ability(AbilitiesDatabaseConn dbConn)
        {
            this.dbConn = dbConn;
            
            abilityName = this.dbConn.getAbiltyName();
            cooldown = this.dbConn.getAbilityCooldown();
            keyCode = this.dbConn.getAbilityKeyCode();
            abilityType = this.dbConn.getAbilityType();
            isActive = false;
        }

        public Ability()
        {
            this.abilityName = "";
            this.cooldown = 0f;
            this.keyCode = "";
            isActive = false;
        }

        public abstract void startAbility();

        public abstract bool isAbilityActive();
        
        public string getKeyCode()
        {
            return keyCode;
        }

        public float getCooldown()
        {
            return cooldown;
        }

        public AbilityType getAbilityType()
        {
            return abilityType;
        }

        public void setCharacterAnimationController(CharacterAnimationController characterGFX)
        {
            this.characterGFX = characterGFX;
        }
    }
}