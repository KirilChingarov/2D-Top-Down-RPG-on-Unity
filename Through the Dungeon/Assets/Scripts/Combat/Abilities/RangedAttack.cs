using DatabasesScripts;
using UnityEngine;

namespace Combat.Abilities
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

            abilityRange = dbConn.GETAbilityAttackRange();
            projectileSpeed = dbConn.GETProjectileSpeed();
            attackDamage = dbConn.GETAbilityAttackDamage();
        }
        
        public override void StartAbility()
        {
            CharacterGfx.StartRangedAttack();
            MonoBehaviour.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        }

        public override bool IsAbilityActive()
        {
            return false;
        }

        public void BuffRangedAttackDamage(float damage)
        {
            attackDamage += damage;
        }

        public void setAttackDamage(float damage)
        {
            attackDamage = damage;
        }
        
        public float GETRangedAttackDamage()
        {
            return attackDamage;
        }
    }
}