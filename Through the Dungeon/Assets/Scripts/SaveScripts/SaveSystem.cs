using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Player;

namespace SaveScripts
{
    public static class SaveSystem
    {
        public static void SavePlayerData(PlayerController player, GameStateController gameStateController)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.bin", FileMode.Create);
            
            PlayerData data = new PlayerData(SceneManager.GetActiveScene().path, player ,gameStateController);
            
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.bin";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                return data;
            }
            else
            {
                Debug.LogError("Save File doesn't exists!\n" + "path: " + path);
                return null;
            }
        }
    }
}