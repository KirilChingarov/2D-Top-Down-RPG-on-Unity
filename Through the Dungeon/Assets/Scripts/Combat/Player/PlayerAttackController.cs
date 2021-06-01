using Character;
using Combat.Abilities;
using DatabasesScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Combat.Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        [FormerlySerializedAs("m_CharacterAnimationController")] public CharacterAnimationController characterAnimationController;
        private float basicAttackDamage = 0f;
        private FireAttack fireAttack;
        private RangedAttack rangedAttack;
        private DefensiveAbility defensiveAbility;
        private HealingAbility healingAbility;

        public void Attack()
        {
            characterAnimationController.StartAttack();
        }

        public void ApplyDamage(string gameObjectName)
        {
            float damage;
            switch (gameObjectName)
            {
                case "BasicAttack":
                    damage = basicAttackDamage;
                    break;
                case "FireAttack":
                    damage = fireAttack.GETFireAttackDamage();
                    break;
                default:
                    damage = 0f;
                    break;
            }
        
            transform.Find(gameObjectName).GetComponent<AttackHitbox>().Attack(damage);
        }

        public void SetAttackRange(float attackRange)
        {
            GetComponentInChildren<AttackHitbox>().SetAttackRange(attackRange);
        }

        public void SetBasicAttackDamage(float attackDamage)
        {
            basicAttackDamage = attackDamage;
        }

        public void SetUpFireAttack()
        {
            fireAttack = new FireAttack(GameObject.Find("FireAttack"), 
                new AbilitiesDatabaseConn("FireAttack"));
            fireAttack.SetCharacterAnimationController(characterAnimationController);
        }

        public void FireAttack()
        {
            fireAttack.StartAbility();
            GameObject.Find("FireAttack").GetComponent<FireAttackAnimation>().TriggerFireVFX();
        }

        public void setFireAttackDamage(float damage)
        {
            fireAttack.setAttackDamage(damage);
        }

        public float getFireAttackDamage()
        {
            return fireAttack.GETFireAttackDamage();
        }

        public void BuffFireAttackDamage(float damage)
        {
            fireAttack.BuffAttackDamage(damage);
        }
    
        public string GETFireAttackKeyCode()
        {
            return fireAttack.GETKeyCode();
        }

        public float GETFireAttackCooldown()
        {
            return fireAttack.GETCooldown();
        }

        public void SetUpRangedAttack()
        {
            rangedAttack = new RangedAttack(GameObject.Find("RangedAttack").transform,
                Resources.Load("Prefabs/VFX/WindSlash") as GameObject, 
                new AbilitiesDatabaseConn("RangedAttack"));
            rangedAttack.SetCharacterAnimationController(characterAnimationController);
        }

        public void RangedAttack()
        {
            rangedAttack.StartAbility();
        }

        public void setRangedAttackDamage(float damage)
        {
            rangedAttack.setAttackDamage(damage);
        }

        public float getRangedAttackDamage()
        {
            return rangedAttack.GETRangedAttackDamage();
        }

        public void BuffRangedAttackDamage(float damage)
        {
            rangedAttack.BuffRangedAttackDamage(damage);
        }

        public string GETRangedAttackKeyCode()
        {
            return rangedAttack.GETKeyCode();
        }

        public float GETRangedAttackCooldown()
        {
            return rangedAttack.GETCooldown();
        }

        public void SetUpDefensiveAbility()
        {
            defensiveAbility = new DefensiveAbility(new AbilitiesDatabaseConn("DefensiveAbility"));
            defensiveAbility.SetCharacterAnimationController(characterAnimationController);
        }

        public void DefensiveAbility()
        {
            defensiveAbility.StartAbility();
            Invoke(nameof(DisableDefensiveAbility), defensiveAbility.GETAbilityDuration());
        }

        public void setDefenseDamageReduction(float damageReduction)
        {
            defensiveAbility.setDamageReduction(damageReduction);
        }

        public float getDefensiveDamageReduction()
        {
            return defensiveAbility.GETDamageReduction();
        }

        public void BuffDefensiveDamageReduction(float amount)
        {
            defensiveAbility.BuffDamageReduction(amount);
        }
    
        private void DisableDefensiveAbility()
        {
            defensiveAbility.DisableAbillity();
        }

        public bool IsDefensiveAbilityActive()
        {
            return defensiveAbility.IsAbilityActive();
        }

        public float GETDefensiveAbilityDmgReduction()
        {
            return defensiveAbility.GETDamageReduction();
        }

        public string GETDefensiveAbilityKeyCode()
        {
            return defensiveAbility.GETKeyCode();
        }

        public float GETDefensiveAbilityCooldown()
        {
            return defensiveAbility.GETCooldown();
        }

        public void SetUpHealingAbility()
        {
            healingAbility = new HealingAbility(new AbilitiesDatabaseConn("HealingAbility"));
            healingAbility.SetCharacterAnimationController(characterAnimationController);
        }

        public void Heal()
        {
            healingAbility.StartAbility();
        }

        public string GETHealingAbilityKeyCode()
        {
            return healingAbility.GETKeyCode();
        }

        public float GETHealingAbilityCooldown()
        {
            return healingAbility.GETCooldown();
        }

        public void BuffHealingAbilityAmount(float amount)
        {
            healingAbility.BuffHealingAmount(amount);
        }

        public void setHealingAmount(float healingAmount)
        {
            healingAbility.setHealingAmount(healingAmount);
        }

        public float GETHealingAmount()
        {
            return healingAbility.GETHealingAmount();
        }
    }
}
