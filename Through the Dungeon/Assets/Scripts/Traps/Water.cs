using System;
using Player;
using UnityEngine;

namespace Traps
{
    public class Water : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("Colliding with: " + other.gameObject.name);
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Colliding With Player");
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