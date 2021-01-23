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
        private float attackDamage = 0f;

        public RangedAttack(Transform shootingPoint, GameObject projectilePrefab, AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            this.shootingPoint = shootingPoint;
            projectile = projectilePrefab;

            abilityRange = dbConn.getAbilityAttackRange();
            projectileSpeed = dbConn.getProjectileSpeed();
            attackDamage = dbConn.getAbilityAttackDamage();
        }
        
        public override void startAbility()
        {
            Debug.Log("Shooting Wind Slash");
            characterGFX.startRangedAttack();
            Debug.Log(shootingPoint.rotation);
            MonoBehaviour.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        }

        public override bool isAbilityActive()
        {
            return false;
        }

        public float getRangedAttackDamage()
        {
            return attackDamage;
        }
    }
}