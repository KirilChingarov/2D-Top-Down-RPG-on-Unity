using System;
using UnityEngine;

namespace Objects
{
    public class RoomClearance : MonoBehaviour
    {
        public DoorSpriteChanger[] doors;

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
        }

        private void closePaths()
        {
            foreach (var door in doors)
            {
                door.closeDoor();
            }
        }
    }
}