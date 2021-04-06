using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class LevelSelect : MonoBehaviour
    {
        private string levelName;
        public Text text;
        public string[] levels = {"Forest_1", "Forest_2", "Forest_3", "Forest_4"};
        private int currentLevel = 0;

        public void Right()
        {
            if (currentLevel < levels.Length - 1)
            {
                currentLevel++;
                levelName = levels[currentLevel];
                text.text = levelName;
            }
            else if (currentLevel >= levels.Length - 1)
            {
                currentLevel = 0;
                levelName = levels[currentLevel];
                text.text = levelName;
            }
        }

        public void Left()
        {
            if (currentLevel > 0)
            {
                currentLevel--;
                levelName = levels[currentLevel];
                text.text = levelName;
            }
            else if (currentLevel <= 0)
            {
                currentLevel = levels.Length - 1;
                levelName = levels[currentLevel];
                text.text = levelName;
            }
        }

        public void setCurrentLevel(int index)
        {
            currentLevel = index;
            levelName = levels[currentLevel];
            text.text = levelName;
        }
        
        public int getCurrentLevelIndex()
        {
            return currentLevel;
        }

        public string getCurrentLevel()
        {
            return levelName;
        }
    }
}