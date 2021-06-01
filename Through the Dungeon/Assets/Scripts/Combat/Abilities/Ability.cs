using Character;
using DatabasesScripts;
using Enums;

namespace Combat.Abilities
{
    public abstract class Ability
    {
        protected string AbilityName;
        protected float Cooldown;
        protected string KeyCode;
        protected AbilityType AbilityType;
        protected bool IsActive;
        protected CharacterAnimationController CharacterGfx;
        protected AbilitiesDatabaseConn DBConn;

        public Ability(AbilitiesDatabaseConn dbConn)
        {
            this.DBConn = dbConn;
            
            AbilityName = this.DBConn.GETAbiltyName();
            Cooldown = this.DBConn.GETAbilityCooldown();
            KeyCode = this.DBConn.GETAbilityKeyCode();
            AbilityType = this.DBConn.GETAbilityType();
            IsActive = false;
        }

        public Ability()
        {
            this.AbilityName = "";
            this.Cooldown = 0f;
            this.KeyCode = "";
            IsActive = false;
        }

        public abstract void StartAbility();

        public abstract bool IsAbilityActive();
        
        public string GETKeyCode()
        {
            return KeyCode;
        }

        public float GETCooldown()
        {
            return Cooldown;
        }

        public AbilityType GETAbilityType()
        {
            return AbilityType;
        }

        public void SetCharacterAnimationController(CharacterAnimationController characterGfx)
        {
            this.CharacterGfx = characterGfx;
        }
    }
}