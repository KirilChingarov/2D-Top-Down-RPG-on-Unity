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
        private string dbPath;
        private SqliteConnection conn;
        private int playerCharacterId;
        
        public PlayerDatabaseConn(string databasePath)
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
            cmd.CommandText = "UPDATE characterMovement " + 
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
            cmd.CommandText = "SELECT moveSpeed FROM characterMovement " + 
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
    }
}