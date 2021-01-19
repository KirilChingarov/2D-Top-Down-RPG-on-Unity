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

        public AbilitiesDatabaseConn(string databasePath, string abilityName)
        {
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
            cmd.CommandText = "SELECT AbilityTypes.typeName FROM AbilityIds" +
                              "INNER JOIN AbilityTypesConnections" +
                              "ON AbilityIds.abilityId = AbilityTypesConnections.abilityId" +
                              "INNER JOIN AbilityTypes" +
                              "ON AbilityTypes.typeId = AbilityTypesConnections.abilityTypeId" +
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
    }
}