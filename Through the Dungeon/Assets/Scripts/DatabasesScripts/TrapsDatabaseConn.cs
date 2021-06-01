using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

namespace DatabasesScripts
{
    public class TrapsDatabaseConn
    {
        private string dbPath;
        private SqliteConnection conn;
        private int trapId;

        public TrapsDatabaseConn(string trapName)
        {
            dbPath = "URI=file:" + Application.dataPath + "/Database.db";
            conn = new SqliteConnection(dbPath);
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapId FROM Traps " + 
                              "WHERE trapName = @trapName";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapName",
                    Value = trapName
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            trapId = result.GetInt32(0);
            
            conn.Close();
        }

        public int GETTrapId()
        {
            return trapId;
        }

        public float GETTrapCooldown()
        {
            float cooldown = 0f;
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapCooldown FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = trapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            cooldown = result.GetFloat(0);
            
            conn.Close();

            return cooldown;
        }
        
        public float GETTrapDuration()
        {
            float duration = 0f;
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapDuration FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = trapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            duration = result.GetFloat(0);
            
            conn.Close();

            return duration;
        }
        
        public float GETTrapDamage()
        {
            float damage = 0f;
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapDamage FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = trapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            damage = result.GetFloat(0);
            
            conn.Close();

            return damage;
        }
        
        public float GETTrapRange()
        {
            float range = 0f;
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapRange FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = trapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            range = result.GetFloat(0);
            
            conn.Close();

            return range;
        }
        
        public float GETTrapProjectileSpeed()
        {
            float speed = 0f;
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapProjectileSpeed FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = trapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            speed = result.GetFloat(0);
            
            conn.Close();

            return speed;
        }
    }
}