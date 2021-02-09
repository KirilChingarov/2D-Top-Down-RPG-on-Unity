using UnityEngine;
using UnityEngine.SceneManagement;
using SaveScripts;
using UnityEditor;

namespace UIScripts
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("Scenes/Rooms/Forest_Entry", LoadSceneMode.Single);
            
            GameObject gameStateControllerObject = GameObject.Find("GameStateController");
            GameStateController gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

            gameStateController.isLoadedFromSave = false;
        }

        public void LoadSave()
        {
            PlayerData playerData = SaveSystem.LoadPlayer();

            GameObject gameStateControllerObject = GameObject.Find("GameStateController");
            GameStateController gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

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
            
            SceneManager.LoadScene(playerData.levelPath);
        }

        public void Quit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}