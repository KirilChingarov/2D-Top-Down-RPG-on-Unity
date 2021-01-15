using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

namespace DatabasesScripts
{
    public class EnemyDatabaseConn
    {
        private string dbPath;
        private SqliteConnection conn;
        private int enemyCharacterId;

        public EnemyDatabaseConn(String databasePath, String enemyName)
        {
            // databasePath - the path to the .db file in Databases folder
            dbPath = "URI=file:" + Application.dataPath + "/Scripts/Databases/" + databasePath;
            conn = new SqliteConnection(dbPath);
            
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterId FROM characterIds " + 
                              "WHERE characterName = @characterName";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterName",
                    Value = enemyName
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            enemyCharacterId = result.GetInt32(0);
            conn.Close();
        }

        public int getEnemyCharacterId()
        {
            return enemyCharacterId;
        }

        public float getEnemyMoveSpeed()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT moveSpeed FROM characterStats " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = enemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float moveSpeed = result.GetFloat(0);
            
            conn.Close();

            return moveSpeed;
        }
        
        public void setMoveSpeed(float newMoveSpeed)
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE characterStats " + 
                              "SET moveSpeed = @newMoveSpeed " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "newMoveSpeed",
                Value = newMoveSpeed
            });
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "characterId",
                Value = enemyCharacterId
            });

            cmd.ExecuteNonQuery();
            
            conn.Close();
        }
        
        public float getEnemyHealth()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT health FROM characterStats " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = enemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float health = result.GetFloat(0);
            
            conn.Close();

            return health;
        }

        public float getEnemyAttackDamage()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT attackDamage FROM characterStats " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = enemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackDamage = result.GetFloat(0);
            
            conn.Close();

            return attackDamage;
        }
        
        public float getEnemyAttackRange()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT attackRange FROM characterStats " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = enemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackRange = result.GetFloat(0);
            
            conn.Close();

            return attackRange;
        }
        
        public float getEnemyAttackCooldown()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT attackCooldown FROM characterStats " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = enemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackCooldown = result.GetFloat(0);
            
            conn.Close();

            return attackCooldown;
        }
    }
}