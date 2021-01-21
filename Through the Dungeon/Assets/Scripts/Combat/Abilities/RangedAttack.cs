using DatabasesScripts;
using UnityEngine;

namespace Abilities
{
    public class RangedAttack : Ability
    {
        private Transform shootingPoint;
        private GameObject projectile;
        private float abilityRange = 0f;
        private float projectileSpeed = 0f;
        private float abilityDamage = 0f;

        public RangedAttack(Transform shootingPoint, GameObject projectilePrefab, AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            this.shootingPoint = shootingPoint;
            projectile = projectilePrefab;

            abilityRange = dbConn.getAbilityAttackRange();
            projectileSpeed = dbConn.getProjectileSpeed();
            abilityDamage = dbConn.getAbilityAttackDamage();
        }
        
        public override void startAbility()
        {
            
        }

        public override bool isAbilityActive()
        {
            return false;
        }
    }
}