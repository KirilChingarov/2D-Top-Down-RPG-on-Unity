using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIScripts
{
    public class GameOverScreen : MonoBehaviour
    {
        public void Return()
        {
            SceneManager.LoadScene("Scenes/Menus/MainMenu");
        }
    }
}