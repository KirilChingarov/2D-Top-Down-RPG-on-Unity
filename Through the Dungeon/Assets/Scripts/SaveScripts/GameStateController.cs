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
        public bool isLoadedFromSave = false;
        public bool isTransition = false;
        public float playerHealth;
        public float fireCooldown;
        public float fireDamage;
        public float windCooldown;
        public float windDamage;
        public float earthCooldown;
        public float earthDamageReduction;
        public float waterCooldown;
        public float waterHealingAmount;

        public string[] levels = {"Forest_1", "Forest_2", "Forest_3", "Forest_Buffs", "Forest_Boss"};
        public int nextLevel = -1;
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

            isLoadedFromSave = false;
            isTransition = false;
        }

        public void SaveCombatStats()
        {
            PlayerController player = GameObject.Find("PlayerCharacter").GetComponent<PlayerController>();
            playerHealth = player.GETPlayerHealth();
            fireDamage = player.getFireDamage();
            windDamage = player.getWindDamage();
            earthDamageReduction = player.getEarthDamageReduction();
            waterHealingAmount = player.getWaterHealingAmount();
        }

        public GameStateController GetInstance()
        {
            return instance;
        }
    }
}