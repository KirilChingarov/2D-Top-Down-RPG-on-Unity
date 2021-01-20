using Mono.Data.Sqlite;
using System.Data;
using Abilities;
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

        public AbilitiesDatabaseConn(string databasePath, string abilityName)
        {
            this.abilityName = abilityName;
            dbPath = "URI=file:" + Application.dataPath + "/Scripts/Databases/" + databasePath;
            conn = new SqliteConnection(dbPath);
            
            conn.Open();
            
            SqliteCommand cmd = conn.CreateCommand();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityId FROM AbilityIds " + 
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

        public AbilityType getAbilityType()
        {
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT AbilityTypes.typeName FROM AbilityIds " +
                              "INNER JOIN AbilityTypesConnections " +
                              "ON AbilityIds.abilityId = AbilityTypesConnections.abilityId " +
                              "INNER JOIN AbilityTypes " +
                              "ON AbilityTypes.typeId = AbilityTypesConnections.abilityTypeId " +
                              "WHERE AbilityIds.abilityId = @abilityId";
            cmd.Parameters.Add(new SqliteParameter
            {
                ParameterName = "abilityId",
                Value = abilityId
            });

            SqliteDataReader result = cmd.ExecuteReader();
            result.Read();
            string abilityTypeName = result.GetString(0);

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

        public string getAbiltyName()
        {
            return abilityName;
        }

        public float getAbilityCooldown()
        {
            float cooldown = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityCooldown FROM AbilityStats " + 
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

        public float getAbilityAttackRange()
        {
            float attackRange = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityRange FROM AbilityStats " + 
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
        
        public int getAbilityDamageReduction()
        {
            int dmgReduction = 0;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT damageReduction FROM AbilityStats " + 
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
        
        public float getAbilityDuration()
        {
            float abilityDuration = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT abilityDuration FROM AbilityStats " + 
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
        
        public float getAbilityHealingAmount()
        {
            float healingAmount = 0f;

            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT healingAmount FROM AbilityStats " + 
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

        public string getAbilityKeyCode()
        {
            string keyCode = "";
            
            conn.Open();

            SqliteCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT keyCode FROM AbilityKeyCodes " + 
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