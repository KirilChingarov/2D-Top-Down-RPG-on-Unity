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

            gameStateController.levels = new string[levels.Length + 2];
            for (int i = 0; i < levels.Length; i++)
            {
                gameStateController.levels[i] = levels[i].getCurrentLevel();
            }

            Debug.Log("3 level: " + gameStateController.levels[3]);
            Debug.Log("4 level: " + gameStateController.levels[4]);
        }
    }
}