using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace SaveScripts
{
    public class GameStateController : MonoBehaviour
    {
        public static GameStateController instance { get; private set; }
        public bool isLoaded = false;
        [FormerlySerializedAs("levelName")] public string levelPath;
        public float[] playerPosition;
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

        public void SavePlayerData()
        {
            PlayerData data = new PlayerData(SceneManager.GetActiveScene().name, GameObject.Find("PlayerCharacter").GetComponent<PlayerController>());
            
        }

        public GameStateController GetInstance()
        {
            return instance;
        }
    }
}