using System;
using Player;
using UnityEngine;

namespace Objects
{
    public class Water : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().SetIsSwimming(true);
            }
        }
        
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().SetIsSwimming(false);
            }
        }
    }
}