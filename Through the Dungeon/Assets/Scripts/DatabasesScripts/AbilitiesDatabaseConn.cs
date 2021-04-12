using Mono.Data.Sqlite;
using System.Data;
using Enums;
using UnityEngine;

namespace DatabasesScripts
{
    public class AbilitiesDatabaseConn
    {
        
        private string dbPath;
        private SqliteConnection conn;
        private int abilityId;
        private string abilityName = "";

        public AbilitiesDatabaseConn(string abilityName)
        {
            this.abilityName = abilityName;
            dbPath = "URI=file:" + Application.dataPath + "/Database.db";
            conn = new SqliteConnection(dbPath);
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityId FROM Abilities " + 
                              "WHERE abilityName = @abilityName";
            cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "abilityName",
                    Value = abilityName
                }
            );

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            abilityId = result.GetInt32(0);
            
            conn.Close();
        }

        public AbilityType GETAbilityType()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT AbilityTypes.abilityTypeName FROM Abilities " +
                              "LEFT JOIN AbilityTypes " +
                              "ON Abilities.abilityTypeId = AbilityTypes.abilityTypeId " +
                              "WHERE Abilities.abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            string abilityTypeName = result.GetString(0);

            conn.Close();

            return AbilityTypeFromString(abilityTypeName);
        }

        public AbilityType AbilityTypeFromString(string abilityTypeName)
        {
            switch (abilityTypeName)
            {
                case "MeleeAttack":
                    return AbilityType.MeleeAttack;
                case "RangedAttack":
                    return AbilityType.RangedAttack;
                case "DefensiveAbility":
                    return AbilityType.DefensiveAbility;
                case "HealingAbility":
                    return AbilityType.HealingAbility;
            }

            return AbilityType.NotFound;
        }

        public string GETAbiltyName()
        {
            return abilityName;
        }

        public float GETAbilityCooldown()
        {
            float cooldown = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityCooldown FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            cooldown = result.GetFloat(0);
            
            conn.Close();

            return cooldown;
        }
        
        public float GETAbilityAttackDamage()
        {
            float attackDamage = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT attackDamage FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            attackDamage = result.GetFloat(0);
            
            conn.Close();

            return attackDamage;
        }

        public float GETAbilityAttackRange()
        {
            float attackRange = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityRange FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            attackRange = result.GetFloat(0);
            
            conn.Close();

            return attackRange;
        }
        
        public float GETProjectileSpeed()
        {
            float projectileSpeed = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT projectileSpeed FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            projectileSpeed = result.GetFloat(0);
            
            conn.Close();

            return projectileSpeed;
        }
        
        public int GETAbilityDamageReduction()
        {
            int dmgReduction = 0;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT damageReduction FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            dmgReduction = result.GetInt32(0);
            
            conn.Close();

            return dmgReduction;
        }
        
        public float GETAbilityDuration()
        {
            float abilityDuration = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityDuration FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            abilityDuration = result.GetFloat(0);
            
            conn.Close();

            return abilityDuration;
        }
        
        public float GETAbilityHealingAmount()
        {
            float healingAmount = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT healingAmount FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            healingAmount = result.GetFloat(0);
            
            conn.Close();

            return healingAmount;
        }

        public string GETAbilityKeyCode()
        {
            string keyCode = "";
            
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityKeyCode FROM Abilities " + 
                              "WHERE abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            keyCode = result.GetString(0);

            conn.Close();

            return keyCode;
        }
    }
}