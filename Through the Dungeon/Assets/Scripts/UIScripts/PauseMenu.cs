using System;
using UnityEngine;

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
    }
}