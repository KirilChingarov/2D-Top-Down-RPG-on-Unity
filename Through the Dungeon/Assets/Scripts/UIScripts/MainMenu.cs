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
        }

        public void LoadSave()
        {
            PlayerData playerData = SaveSystem.LoadPlayer();

            GameObject gameStateControllerObject = GameObject.Find("GameStateController");
            GameStateController gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

            gameStateController.isLoaded = true;
            gameStateController.levelPath = playerData.levelPath;
            gameStateController.playerHealth = playerData.health;
            gameStateController.playerPosition = new float[3];
            for (int i = 0; i < 3; i++)
            {
                gameStateController.playerPosition[i] = playerData.position[i];
            }
            
            SceneManager.LoadScene(playerData.levelPath);
        }

        public void Quit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}