using System;
using DatabasesScripts;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Objects
{
    public class Spikes : MonoBehaviour
    {
        private bool isActive = false;
        private Sprite[] sprites;
        private float cooldown;
        private float duration;
        private float damage;
        private float nextDamage = 0f;
        public float timeToActivate = 1f;

        private void Awake()
        {
            sprites = Resources.LoadAll<Sprite>("Sprites/Traps/Spikes");
            cooldown = new TrapsDatabaseConn("Spikes").GETTrapCooldown();
            duration = new TrapsDatabaseConn("Spikes").GETTrapDuration();
            damage = new TrapsDatabaseConn("Spikes").GETTrapDamage();
            GetComponent<Collider2D>().enabled = false;
            
            Invoke("ActivateSpikes", timeToActivate);
        }

        private void ActivateSpikes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
            }
            GetComponent<Collider2D>().enabled = true;
            isActive = true;
            Invoke("DisableSpikes", duration);
        }

        private void DisableSpikes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
            }
            GetComponent<Collider2D>().enabled = false;
            isActive = false;
            Invoke("ActivateSpikes", cooldown);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && isActive && Time.time >= nextDamage)
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
                nextDamage = Time.time + duration + 0.1f;
            }
        }
    }
}