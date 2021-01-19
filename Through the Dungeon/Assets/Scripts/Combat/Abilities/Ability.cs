using Character;

namespace Abilities
{
    public abstract class Ability
    {
        protected string abilityName;
        protected float cooldown;
        protected string keyCode;
        protected bool isActive;
        protected CharacterAnimationController characterGFX;

        public Ability(string abilityName, float cooldown, string keyCode)
        {
            this.abilityName = abilityName;
            this.cooldown = cooldown;
            this.keyCode = keyCode;
            isActive = false;
        }

        public abstract void startAbility();

        public abstract bool isAbilityActive();
    }
}