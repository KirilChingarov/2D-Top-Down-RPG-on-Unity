using System.Collections;
using System.Collections.Generic;
using DatabasesScripts;
using UnityEngine;

namespace Character
{
    public class CharacterStats
    {
        private float health;
        private float moveSpeed;
        private float attackDamage;
        private float attackRange;
        private float attackCooldown;

        public CharacterStats(PlayerDatabaseConn dbConn)
        {
            health = dbConn.getPlayerHealth();
            moveSpeed = dbConn.getPlayerMoveSpeed();
            attackDamage = dbConn.getPlayerAttackDamage();
            attackRange = dbConn.getPlayerAttackRange();
            attackCooldown = dbConn.getPlayerAttackCooldown();
        }
        
        public CharacterStats(EnemyDatabaseConn dbConn)
        {
            health = dbConn.getEnemyHealth();
            moveSpeed = dbConn.getEnemyMoveSpeed();
            attackDamage = dbConn.getEnemyAttackDamage();
            attackRange = dbConn.getEnemyAttackRange();
            attackCooldown = dbConn.getEnemyAttackCooldown();
        }

        public float getMoveSpeed()
        {
            return moveSpeed;
        }

        public void setMoveSpeed(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public float getHealth()
        {
            return health;
        }

        public void setHealth(float health)
        {
            this.health = health;
        }

        public float getAttackDamage()
        {
            return attackDamage;
        }

        public void setAttackDamage(float attackDamage)
        {
            this.attackDamage = attackDamage;
        }

        public float getAttackRange()
        {
            return attackRange;
        }

        public void setAttackRange(float attackRange)
        {
            this.attackRange = attackRange;
        }

        public float getAttackCooldown()
        {
            return attackCooldown;
        }

        public void setAttackCooldown(float attackCooldown)
        {
            this.attackCooldown = attackCooldown;
        }
    }    
}

