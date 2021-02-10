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
                Debug.Log(i + " level: " + levels[i].getCurrentLevel());
                gameStateController.levels[i] = levels[i].getCurrentLevel();
            }

            gameStateController.levels[3] = "Forest_Buffs";
            Debug.Log("3 level: " + gameStateController.levels[3]);
            gameStateController.levels[4] = "Scenes/Menus/WinnerScreen";
            Debug.Log("4 level: " + gameStateController.levels[4]);
        }
    }
}