using UnityEngine;

namespace Objects
{
    public class NextRoomDoor : MonoBehaviour
    {
        public RoomLoader roomLoader;
        public int targetRoomIndex;
        public Transform targetSpawningPosition;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                roomLoader.LoadRoom(targetRoomIndex, targetSpawningPosition);
            }
        }
    }
}