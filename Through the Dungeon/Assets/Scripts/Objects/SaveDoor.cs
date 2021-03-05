using System;
using System.Collections;
using Player;
using SaveScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Objects
{
    public class SaveDoor : MonoBehaviour
    {
        public CanvasGroup saveIcon;
        public Image saveDotsImage;
        public Sprite[] saveDots;

        private void Awake()
        {
            GameStateController gameStateController =
                GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance();

            if (!(gameStateController.isLoadedFromSave && 
                  gameStateController.levels[gameStateController.nextLevel] == SceneManager.GetActiveScene().name))
            {
                StartCoroutine(SaveIconAnimation());
                SaveSystem.SavePlayerData(GameObject.Find("PlayerCharacter").GetComponent<PlayerController>(),
                    GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance());
            }
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
        }
    }
}