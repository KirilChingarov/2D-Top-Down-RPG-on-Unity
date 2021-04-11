using System;
using UnityEngine;

namespace Objects
{
    public class RoomClearance : MonoBehaviour
    {
        public DoorSpriteChanger[] doors;
        public GameObject[] blockades;

        public void Awake()
        {
            closePaths();
        }

        public void Update()
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length <= 0) openPaths();
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