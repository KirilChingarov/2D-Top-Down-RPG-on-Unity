using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Objects
{
    public class RoomLoader : MonoBehaviour
    {
        public PlayerController player;
        public Image loadingScreen;
        public GameObject[] rooms;
        private bool roomLoaded;

        public void LoadRoom(int roomIndex, Transform spawningPoint)
        {
            StartCoroutine(enableRooms(roomIndex, spawningPoint));
        }

        private IEnumerator enableRooms(int roomIndex, Transform spawningPoint)
        {
            player.FreezePosition();
            StartCoroutine(showLoadingScreen());

            while (loadingScreen.color.a < 1)
            {
                yield return null;
            }

            for (int i = 0;i < rooms.Length;i++)
            {
                rooms[i].SetActive(i == roomIndex);
            }

            var newPosition = spawningPoint.position;
            GameObject.FindGameObjectWithTag("Player").transform.position = newPosition;
            
            roomLoaded = true;
            player.UnfreezePosition();
            
            StartCoroutine(hideLoadingScreen());
        }

        private IEnumerator showLoadingScreen()
        {
            for(int i = 0;i <= 255;i++)
            {
                var tmpColor = loadingScreen.color;
                tmpColor.a = MapFloat(i, 0, 255, 0, 1);
                loadingScreen.color = tmpColor;
                yield return new WaitForSeconds(0.001f);
            }
        }
        
        private IEnumerator hideLoadingScreen()
        {
            while (!roomLoaded)
            {
                yield return null;
            }
            for(int i = 255;i >= 0;i--)
            {
                var tmpColor = loadingScreen.color;
                tmpColor.a = MapFloat(i, 0, 255, 0, 1);
                loadingScreen.color = tmpColor;
                yield return new WaitForSeconds(0.001f);
            }

            roomLoaded = false;
        }
        
        private static float MapFloat(float value, float low1, float high1, float low2, float high2)
        {
            return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
        }
    }
}