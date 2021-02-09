using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using SaveScripts;

namespace UIScripts
{
    public class PauseMenu : MonoBehaviour
    {
        private bool isPaused = false;
        private GameObject pauseMenu;

        private void Awake()
        {
            pauseMenu = transform.GetChild(0).gameObject;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(isPaused) Resume();
                else Pause();
            }
        }

        public void Pause()
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Resume();
        }

        public void SaveAndQuit()
        {
            SaveSystem.SavePlayerData(GameObject.Find("PlayerCharacter").GetComponent<PlayerController>(),
                GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance());
            SceneManager.LoadScene("Scenes/Menus/MainMenu", LoadSceneMode.Single);
            Resume();
        }
    }
}