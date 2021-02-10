using System;
using SaveScripts;
using UnityEngine;

namespace UIScripts
{
    public class LevelSelectController : MonoBehaviour
    {
        public LevelSelect[] levels;

        private void Awake()
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].setCurrentLevel(i);
            }
        }

        public void Load()
        {
            GameStateController gameStateController =
                GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance();

            gameStateController.levels = new string[levels.Length];
            for (int i = 0; i < levels.Length; i++)
            {
                Debug.Log(i + " " + levels[i].getCurrentLevel());
                gameStateController.levels[i] = levels[i].getCurrentLevel();
            }

            gameStateController.levels[3] = "Forest_Buffs";

        }
    }
}