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

            gameStateController.levels = new string[levels.Length + 3];
            for (int i = 0; i < levels.Length; i++)
            {
                gameStateController.levels[i] = levels[i].getCurrentLevel();
            }

            gameStateController.levels[3] = "Forest_Buffs";
            gameStateController.levels[4] = "Forest_Boss";
            gameStateController.levels[5] = "Scenes/Menus/WinnerScreen";
        }
    }
}