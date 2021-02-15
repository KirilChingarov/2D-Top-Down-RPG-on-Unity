using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

namespace DatabasesScripts
{
    public class TrapsDatabaseConn
    {
        private string m_DBPath;
        private SqliteConnection m_Conn;
        private int m_TrapId;

        public TrapsDatabaseConn(string trapName)
        {
            m_DBPath = "URI=file:" + Application.dataPath + "/Database.db";
            m_Conn = new SqliteConnection(m_DBPath);
            
            m_Conn.Open();
            
            SqliteCommand cmd = m_Conn.CreateCommand();
            
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
            m_TrapId = result.GetInt32(0);
            
            m_Conn.Close();
        }

        public int GETTrapId()
        {
            return m_TrapId;
        }

        public float GETTrapCooldown()
        {
            float cooldown = 0f;
            
            m_Conn.Open();
            
            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapCooldown FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = m_TrapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            cooldown = result.GetFloat(0);
            
            m_Conn.Close();

            return cooldown;
        }
        
        public float GETTrapDuration()
        {
            float duration = 0f;
            
            m_Conn.Open();
            
            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapDuration FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = m_TrapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            duration = result.GetFloat(0);
            
            m_Conn.Close();

            return duration;
        }
        
        public float GETTrapDamage()
        {
            float damage = 0f;
            
            m_Conn.Open();
            
            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapDamage FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = m_TrapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            damage = result.GetFloat(0);
            
            m_Conn.Close();

            return damage;
        }
        
        public float GETTrapRange()
        {
            float range = 0f;
            
            m_Conn.Open();
            
            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapRange FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = m_TrapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            range = result.GetFloat(0);
            
            m_Conn.Close();

            return range;
        }
        
        public float GETTrapProjectileSpeed()
        {
            float speed = 0f;
            
            m_Conn.Open();
            
            SqliteCommand cmd = m_Conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trapProjectileSpeed FROM Traps " + 
                              "WHERE trapId = @trapId";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "trapId",
                    Value = m_TrapId
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            speed = result.GetFloat(0);
            
            m_Conn.Close();

            return speed;
        }
    }
}