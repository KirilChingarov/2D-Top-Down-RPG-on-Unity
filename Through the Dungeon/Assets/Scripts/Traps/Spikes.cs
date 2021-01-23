using System;
using DatabasesScripts;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Traps
{
    public class Spikes : MonoBehaviour
    {
        private bool isActive = false;
        private Sprite[] sprites;
        private float cooldown;
        private float duration;
        private float damage;
        private float nextDamage = 0f;

        private void Awake()
        {
            sprites = Resources.LoadAll<Sprite>("Sprites/Traps/Spikes");
            cooldown = new TrapsDatabaseConn("Spikes").getTrapCooldown();
            duration = new TrapsDatabaseConn("Spikes").getTrapDuration();
            damage = new TrapsDatabaseConn("Spikes").getTrapDamage();
            GetComponent<Collider2D>().enabled = false;
            
            Invoke("ActivateSpikes", 1f);
        }

        private void ActivateSpikes()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = (Sprite) sprites[1];
            isActive = true;
            GetComponent<Collider2D>().enabled = true;
            Debug.Log("Spikes are active");
            Invoke("DisableSpikes", duration);
        }

        private void DisableSpikes()
        {
            GetComponentInChildren<SpriteRenderer>().sprite = (Sprite) sprites[0];
            isActive = false;
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("Spikes are disabled");
            Invoke("ActivateSpikes", cooldown);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && isActive && Time.time >= nextDamage)
            {
                other.gameObject.GetComponent<PlayerController>().takeDamage(damage);
                Debug.Log("Player spiked!");
                nextDamage = Time.time + duration + 0.1f;
            }
        }
    }
}