using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

namespace DatabasesScripts
{
    public class PlayerDatabaseConn
    {
        private string m_DBPath;
        private SqliteConnection m_Conn;
        private int m_PlayerCharacterId;
        
        public PlayerDatabaseConn()
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
                    Value = "PlayerCharacter"
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            m_PlayerCharacterId = result.GetInt32(0);
            m_Conn.Close();
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
                Value = m_PlayerCharacterId
            });

            cmd.ExecuteNonQuery();
            
            m_Conn.Close();
        }

        public int GETPlayerCharacterId()
        {
            return m_PlayerCharacterId;
        }

        public float GETPlayerMoveSpeed()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterMoveSpeed FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_PlayerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float moveSpeed = result.GetFloat(0);
            
            m_Conn.Close();

            return moveSpeed;
        }

        public string GETDbPath()
        {
            return m_DBPath;
        }

        public float GETPlayerHealth()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterHealth FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_PlayerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float health = result.GetFloat(0);
            
            m_Conn.Close();

            return health;
        }

        public float GETPlayerAttackDamage()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackDamage FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_PlayerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackDamage = result.GetFloat(0);
            
            m_Conn.Close();

            return attackDamage;
        }
        
        public float GETPlayerAttackRange()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackRange FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_PlayerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackRange = result.GetFloat(0);
            
            m_Conn.Close();

            return attackRange;
        }
        
        public float GETPlayerAttackCooldown()
        {
            m_Conn.Open();

            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackCooldown FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = m_PlayerCharacterId
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