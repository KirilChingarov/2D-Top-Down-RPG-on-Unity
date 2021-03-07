using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using SaveScripts;
using Image = UnityEngine.UI.Image;

namespace UIScripts
{
    public class PauseMenu : MonoBehaviour
    {
        private bool isPaused = false;
        private GameObject pauseMenu;
        public CanvasGroup saveIcon;
        public Image saveDotsImage;
        public Sprite[] saveDots;
        private bool saved = false;

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

        private void Pause()
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

        public void SaveProgress()
        {
            saved = false;
            StartCoroutine(SaveIconAnimation());
            SaveSystem.SavePlayerData(GameObject.Find("PlayerCharacter").GetComponent<PlayerController>(),
                GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance());
        }

        public void Quit()
        {
            SceneManager.LoadScene("Scenes/Menus/MainMenu", LoadSceneMode.Single);
            Resume();
        }

        public void SaveAndQuit()
        {
            SaveProgress();
            StartCoroutine(QuitAfterSave());
        }

        private IEnumerator QuitAfterSave()
        {
            while (!saved)
            {
                yield return null;
            }
            Quit();
        }

        private IEnumerator SaveIconAnimation()
        {
            saveIcon.alpha = 1;
            for (int counter = 0; counter < 3; counter++)
            {
                for (int i = 0; i < 6; i++)
                {
                    saveDotsImage.sprite = saveDots[i];
                    yield return new WaitForSecondsRealtime(0.05f);
                }
            }

            saveIcon.alpha = 0;
            saved = true;
        }
    }
}