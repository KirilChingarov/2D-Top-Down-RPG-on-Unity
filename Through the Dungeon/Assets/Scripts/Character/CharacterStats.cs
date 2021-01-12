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

        public CharacterStats(PlayerDatabaseConn dbConn)
        {
            health = dbConn.getPlayerHealth();
            moveSpeed = dbConn.getPlayerMoveSpeed();
            attackDamage = dbConn.getPlayerAttackDamage();
        }
        
        public CharacterStats(EnemyDatabaseConn dbConn)
        {
            health = dbConn.getEnemyHealth();
            moveSpeed = dbConn.getEnemyMoveSpeed();
            attackDamage = dbConn.getEnemyAttackDamage();
        }

        public float getMoveSpeed()
        {
            return moveSpeed;
        }

        public float getHealth()
        {
            return health;
        }

        public float getAttackDamage()
        {
            return attackDamage;
        }
    }    
}

