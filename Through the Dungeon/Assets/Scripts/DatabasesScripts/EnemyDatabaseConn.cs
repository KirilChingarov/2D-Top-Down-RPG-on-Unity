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
        private string m_DBPath;
        private SqliteConnection m_Conn;
        private int m_EnemyCharacterId;

        public EnemyDatabaseConn(string enemyName)
        {
            // databasePath - the path to the .db file in Databases folder
            m_DBPath = "URI=file:" + Application.dataPath + "/Database.db";
            m_Conn = new SqliteConnection(m_DBPath);
            
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterId FROM Characters " + 
                              "WHERE characterName = @characterName";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterName",
                    Value = enemyName
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            m_EnemyCharacterId = result.GetInt32(0);
            m_Conn.Close();
        }

        public int GETEnemyCharacterId()
        {
            return m_EnemyCharacterId;
        }

        public float GETEnemyMoveSpeed()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterMoveSpeed FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_EnemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float moveSpeed = result.GetFloat(0);
            
            m_Conn.Close();

            return moveSpeed;
        }
        
        public void SetMoveSpeed(float newMoveSpeed)
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Characters " + 
                              "SET characterMoveSpeed = @newMoveSpeed " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "newMoveSpeed",
                Value = newMoveSpeed
            });
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "characterId",
                Value = m_EnemyCharacterId
            });

            cmd.ExecuteNonQuery();
            
            m_Conn.Close();
        }
        
        public float GETEnemyHealth()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterHealth FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_EnemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float health = result.GetFloat(0);
            
            m_Conn.Close();

            return health;
        }

        public float GETEnemyAttackDamage()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackDamage FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_EnemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackDamage = result.GetFloat(0);
            
            m_Conn.Close();

            return attackDamage;
        }
        
        public float GETEnemyAttackRange()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackRange FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_EnemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackRange = result.GetFloat(0);
            
            m_Conn.Close();

            return attackRange;
        }
        
        public float GETEnemyAttackCooldown()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackCooldown FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_EnemyCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackCooldown = result.GetFloat(0);
            
            m_Conn.Close();

            return attackCooldown;
        }
    }
}