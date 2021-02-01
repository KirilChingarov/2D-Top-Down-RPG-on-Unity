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
            AsyncOperation loading = SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Single);
            StartCoroutine(ShowLoadingProgress(loading));
            Resume();
        }

        IEnumerator ShowLoadingProgress(AsyncOperation loading)
        {
            while (!loading.isDone)
            {
                Debug.Log("Progress: " + loading.progress);
                yield return null;
            }
        }

        public void SaveAndQuit()
        {
            SaveSystem.SavePlayerData(GameObject.Find("PlayerCharacter").GetComponent<PlayerController>());
        }
    }
}