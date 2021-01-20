using Character;
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

        public Ability(string abilityName, float cooldown, string keyCode)
        {
            this.abilityName = abilityName;
            this.cooldown = cooldown;
            this.keyCode = keyCode;
            this.abilityType = AbilityType.NotFound;
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
    }
}