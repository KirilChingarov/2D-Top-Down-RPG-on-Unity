using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveScripts
{
    public class GameStateController : MonoBehaviour
    {
        public static GameStateController instance { get; private set; }
        public bool isLoaded = false;
        public string levelName;
        public float[] playerPosition = new float[3];
        public float playerHealth;
        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /*public void LoadPlayerData(PlayerData data)
        {
            PlayerController player = GameObject.Find("PlayerController").GetComponent<PlayerController>();

            player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        }*/

        public void SavePlayerData()
        {
            PlayerData data = new PlayerData(SceneManager.GetActiveScene().name, GameObject.Find("PlayerCharacter").GetComponent<PlayerController>());
            
        }
    }
}