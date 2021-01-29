using DatabasesScripts;
using UnityEngine;

namespace Abilities
{
    public class RangedAttack : Ability
    {
        private Transform m_ShootingPoint;
        private GameObject m_Projectile;
        private float m_AbilityRange = 0f;
        private float m_ProjectileSpeed = 0f;
        private float m_AttackDamage = 0f;

        public RangedAttack(Transform shootingPoint, GameObject projectilePrefab, AbilitiesDatabaseConn dbConn) : base(dbConn)
        {
            this.m_ShootingPoint = shootingPoint;
            m_Projectile = projectilePrefab;

            m_AbilityRange = dbConn.GETAbilityAttackRange();
            m_ProjectileSpeed = dbConn.GETProjectileSpeed();
            m_AttackDamage = dbConn.GETAbilityAttackDamage();
        }
        
        public override void StartAbility()
        {
            CharacterGfx.StartRangedAttack();
            MonoBehaviour.Instantiate(m_Projectile, m_ShootingPoint.position, m_ShootingPoint.rotation);
        }

        public override bool IsAbilityActive()
        {
            return false;
        }

        public float GETRangedAttackDamage()
        {
            return m_AttackDamage;
        }
    }
}