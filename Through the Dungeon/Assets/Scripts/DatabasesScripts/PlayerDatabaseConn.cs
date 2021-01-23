﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

namespace DatabasesScripts
{
    public class PlayerDatabaseConn
    {
        private string dbPath;
        private SqliteConnection conn;
        private int playerCharacterId;
        
        public PlayerDatabaseConn()
        {
            // databasePath - the path to the .db file in Databases folder
            dbPath = "URI=file:" + Application.dataPath + "/Scripts/Database/Database.db";
            conn = new SqliteConnection(dbPath);
            
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterId FROM Characters " + 
                              "WHERE characterName = @characterName";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterName",
                    Value = "playerCharacter"
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            playerCharacterId = result.GetInt32(0);
            conn.Close();
        }

        public void setMoveSpeed(float newMoveSpeed)
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

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
                Value = playerCharacterId
            });

            cmd.ExecuteNonQuery();
            
            conn.Close();
        }

        public int getPlayerCharacterId()
        {
            return playerCharacterId;
        }

        public float getPlayerMoveSpeed()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterMoveSpeed FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = playerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float moveSpeed = result.GetFloat(0);
            
            conn.Close();

            return moveSpeed;
        }

        public string getDbPath()
        {
            return dbPath;
        }

        public float getPlayerHealth()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterHealth FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = playerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float health = result.GetFloat(0);
            
            conn.Close();

            return health;
        }

        public float getPlayerAttackDamage()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackDamage FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = playerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackDamage = result.GetFloat(0);
            
            conn.Close();

            return attackDamage;
        }
        
        public float getPlayerAttackRange()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackRange FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = playerCharacterId
                }
            );

            var result = cmd.ExecuteReader();
            result.Read();
            float attackRange = result.GetFloat(0);
            
            conn.Close();

            return attackRange;
        }
        
        public float getPlayerAttackCooldown()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT characterAttackCooldown FROM Characters " + 
                              "WHERE characterId = @characterId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "characterId",
                    Value = playerCharacterId
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