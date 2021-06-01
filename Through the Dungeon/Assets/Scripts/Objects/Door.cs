using System.Collections;
using SaveScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class Door : MonoBehaviour
    {
        public bool isOpen;
        public string nextScene = "";
        public Animator crossFade;

        private void Awake()
        {
            isOpen = false;
            var spriteChanger = GetComponent<DoorSpriteChanger>();
            if(spriteChanger != null) spriteChanger.closeDoor();
        }

        public void Update()
        {
            int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemyCount <= 0)
            {
                isOpen = true;
                var spriteChanger = GetComponent<DoorSpriteChanger>();
                if(spriteChanger != null) spriteChanger.openDoor();
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && isOpen)
            {
                if (nextScene == "")
                {
                    GameStateController gameStateController = GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance();
                    gameStateController.SaveCombatStats();
                    gameStateController.isTransition = true;
                    gameStateController.nextLevel++;
                    nextScene = gameStateController.levels[gameStateController.nextLevel];
                    //SceneManager.LoadScene(nextScene);
                    StartCoroutine(LoadNextLevel(nextScene));
                }
                else
                {
                    //SceneManager.LoadScene(nextScene);
                    StartCoroutine(LoadNextLevel(nextScene));
                }
            }
        }

        IEnumerator LoadNextLevel(string levelName)
        {
            crossFade.SetTrigger("Start");
            
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene(nextScene);
        }
    }
}