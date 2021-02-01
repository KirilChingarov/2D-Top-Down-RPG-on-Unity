using UnityEngine;
using UnityEngine.SceneManagement;
using SaveScripts;

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
            Debug.Log(playerData.levelName);
            Debug.Log(playerData.health);
            Debug.Log(playerData.position[0]);
            Debug.Log(playerData.position[1]);
            Debug.Log(playerData.position[2]);

            GameObject gameStateControllerObject = GameObject.Find("GameStateController");
            GameStateController gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

            gameStateController.isLoaded = true;
            gameStateController.levelName = playerData.levelName;
            for (int i = 0; i < 3; i++)
            {
                gameStateController.playerPosition[i] = playerData.position[i];
            }

            Scene sceneToLoad = SceneManager.GetSceneByName(playerData.levelName);
            SceneManager.MoveGameObjectToScene(gameStateControllerObject, sceneToLoad);
            SceneManager.LoadScene(sceneToLoad.name);
        }
    }
}