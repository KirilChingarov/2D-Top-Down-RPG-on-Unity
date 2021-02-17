using System.Collections;
using System.Collections.Generic;
using DatabasesScripts;
using UnityEngine;

namespace Character
{
    public class CharacterStats
    {
        private float m_Health;
        private float m_MAXHealth;
        private float m_MoveSpeed;
        private float m_AttackDamage;
        private float m_AttackRange;
        private float m_AttackCooldown;

        public CharacterStats(PlayerDatabaseConn dbConn)
        {
            m_Health = dbConn.GETPlayerHealth();
            m_MAXHealth = m_Health;
            m_MoveSpeed = dbConn.GETPlayerMoveSpeed();
            m_AttackDamage = dbConn.GETPlayerAttackDamage();
            m_AttackRange = dbConn.GETPlayerAttackRange();
            m_AttackCooldown = dbConn.GETPlayerAttackCooldown();
        }
        
        public CharacterStats(EnemyDatabaseConn dbConn)
        {
            m_Health = dbConn.GETEnemyHealth();
            m_MAXHealth = m_Health;
            m_MoveSpeed = dbConn.GETEnemyMoveSpeed();
            m_AttackDamage = dbConn.GETEnemyAttackDamage();
            m_AttackRange = dbConn.GETEnemyAttackRange();
            m_AttackCooldown = dbConn.GETEnemyAttackCooldown();
        }

        public float GETMoveSpeed()
        {
            return m_MoveSpeed;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            this.m_MoveSpeed = moveSpeed;
        }

        public float GETHealth()
        {
            return m_Health;
        }

        public void SetHealth(float health)
        {
            this.m_Health = health;
        }

        public float GETAttackDamage()
        {
            return m_AttackDamage;
        }

        public void SetAttackDamage(float attackDamage)
        {
            this.m_AttackDamage = attackDamage;
        }

        public float GETAttackRange()
        {
            return m_AttackRange;
        }

        public void SetAttackRange(float attackRange)
        {
            this.m_AttackRange = attackRange;
        }

        public float GETAttackCooldown()
        {
            return m_AttackCooldown;
        }

        public void SetAttackCooldown(float attackCooldown)
        {
            this.m_AttackCooldown = attackCooldown;
        }

        public void TakeDamage(float damage)
        {
            m_Health -= damage;
        }

        public void Heal(float healAmount)
        {
            m_Health += healAmount;
            if (m_Health > m_MAXHealth)
            {
                m_Health = m_MAXHealth;
            }
        }
    }    
}

