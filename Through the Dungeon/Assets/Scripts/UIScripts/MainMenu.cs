using UnityEngine;
using UnityEngine.SceneManagement;
using SaveScripts;
using UnityEditor;

namespace UIScripts
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameObject levelsScreen;
        public LevelSelectController levels;
        
        public void Play()
        {
            SceneManager.LoadScene("Scenes/Rooms/Forest_Entry", LoadSceneMode.Single);
            
            GameObject gameStateControllerObject = GameObject.Find("GameStateController");
            GameStateController gameStateController = gameStateControllerObject.GetComponent<GameStateController>().GetInstance();

            gameStateController.isLoadedFromSave = false;
            levels.Load();
        }

        public void LoadSave()
        {
            PlayerData playerData = SaveSystem.LoadPlayer();

            GameObject gameStateControllerObject = GameObject.Find("GameStateController");
            GameStateController gameStateController = gameStateControllerObject.GetComponent<GameStateController>().GetInstance();

            gameStateController.isLoadedFromSave = true;
            gameStateController.playerHealth = playerData.health;
            gameStateController.fireCooldown = playerData.fireCooldown;
            gameStateController.fireDamage = playerData.fireDamage;
            gameStateController.windCooldown = playerData.windCooldown;
            gameStateController.windDamage = playerData.windDamage;
            gameStateController.earthCooldown = playerData.earthCooldown;
            gameStateController.earthDamageReduction = playerData.earthDamageReduction;
            gameStateController.waterCooldown = playerData.waterCooldown;
            gameStateController.waterHealingAmount = playerData.waterHealingAmount;
            
            gameStateController.levels = new string[playerData.levels.Length];
            for (int i = 0; i < gameStateController.levels.Length; i++)
            {
                gameStateController.levels[i] = playerData.levels[i];
            }
            gameStateController.nextLevel = playerData.nextLevel;
            
            SceneManager.LoadScene(playerData.levelPath);
        }

        public void LoadLevelsScreen()
        {
            mainScreen.SetActive(false);
            levelsScreen.SetActive(true);
        }

        public void LoadLevels()
        {
            
        }

        public void BackLevels()
        {
            levelsScreen.SetActive(false);
            mainScreen.SetActive(true);
        }

        public void BackControls()
        {
            
        }

        public void Quit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}