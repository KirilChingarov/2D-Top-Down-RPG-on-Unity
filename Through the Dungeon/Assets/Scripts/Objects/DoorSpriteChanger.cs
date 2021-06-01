using UnityEngine;

namespace Objects
{
    public class DoorSpriteChanger : MonoBehaviour
    {
        public Sprite closedDoor;
        public Sprite openedDoor;

        public void closeDoor()
        {
            GetComponent<SpriteRenderer>().sprite = closedDoor;
            GetComponent<Collider2D>().enabled = false;
        }
        
        public void openDoor()
        {
            GetComponent<SpriteRenderer>().sprite = openedDoor;
            GetComponent<Collider2D>().enabled = true;
        }
    }
}