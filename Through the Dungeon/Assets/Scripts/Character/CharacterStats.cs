using System.Collections;
using System.Collections.Generic;
using DatabasesScripts;
using UnityEngine;

namespace Character
{
    public class CharacterStats
    {
        private float health;
        private float maxHealth;
        private float moveSpeed;
        private float attackDamage;
        private float attackRange;
        private float attackCooldown;

        public CharacterStats(PlayerDatabaseConn dbConn)
        {
            health = dbConn.GETPlayerHealth();
            maxHealth = health;
            moveSpeed = dbConn.GETPlayerMoveSpeed();
            attackDamage = dbConn.GETPlayerAttackDamage();
            attackRange = dbConn.GETPlayerAttackRange();
            attackCooldown = dbConn.GETPlayerAttackCooldown();
        }
        
        public CharacterStats(EnemyDatabaseConn dbConn)
        {
            health = dbConn.GETEnemyHealth();
            maxHealth = health;
            moveSpeed = dbConn.GETEnemyMoveSpeed();
            attackDamage = dbConn.GETEnemyAttackDamage();
            attackRange = dbConn.GETEnemyAttackRange();
            attackCooldown = dbConn.GETEnemyAttackCooldown();
        }

        public float GETMoveSpeed()
        {
            return moveSpeed;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public float GETHealth()
        {
            return health;
        }

        public void SetHealth(float health)
        {
            this.health = health;
        }

        public float GETAttackDamage()
        {
            return attackDamage;
        }

        public void SetAttackDamage(float attackDamage)
        {
            this.attackDamage = attackDamage;
        }

        public float GETAttackRange()
        {
            return attackRange;
        }

        public void SetAttackRange(float attackRange)
        {
            this.attackRange = attackRange;
        }

        public float GETAttackCooldown()
        {
            return attackCooldown;
        }

        public void SetAttackCooldown(float attackCooldown)
        {
            this.attackCooldown = attackCooldown;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
        }

        public void Heal(float healAmount)
        {
            health += healAmount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }    
}

