using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class Door : MonoBehaviour
    {
        public bool isOpen = false;
        public string nextScene = "";

        public void Update()
        {
            int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemyCount <= 0)
            {
                isOpen = true;
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && isOpen)
            {
                Debug.Log("Collided With Door");
                Debug.Log("Loading next scene");
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}