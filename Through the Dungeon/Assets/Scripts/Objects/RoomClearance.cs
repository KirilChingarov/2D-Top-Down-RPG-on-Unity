using UnityEngine;

namespace Objects
{
    public class RoomClearance : MonoBehaviour
    {
        //public Transform room;
        public DoorSpriteChanger[] doors;
        public GameObject[] blockades;
        

        public void Awake()
        {
            closePaths();
        }

        public void Update()
        {
            int enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;/*0;
            for (int i = 0; i < room.childCount; i++)
            {
                if (room.GetChild(i).CompareTag("Enemy")) enemiesCount++;
            }*/
            if(enemiesCount <= 0) openPaths();
        }

        private void openPaths()
        {
            foreach (var door in doors)
            {
                door.openDoor();
            }
            foreach (var blockade in blockades)
            {
                blockade.SetActive(false);
            }
        }

        private void closePaths()
        {
            foreach (var door in doors)
            {
                door.closeDoor();
            }
            foreach (var blockade in blockades)
            {
                blockade.SetActive(true);
            }
        }
    }
}