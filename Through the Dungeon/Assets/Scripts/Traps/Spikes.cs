using System;
using DatabasesScripts;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Traps
{
    public class Spikes : MonoBehaviour
    {
        private bool m_IsActive = false;
        private Sprite[] m_Sprites;
        private float m_Cooldown;
        private float m_Duration;
        private float m_Damage;
        private float m_NextDamage = 0f;
        public float timeToActivate = 1f;

        private void Awake()
        {
            m_Sprites = Resources.LoadAll<Sprite>("Sprites/Traps/Spikes");
            m_Cooldown = new TrapsDatabaseConn("Spikes").GETTrapCooldown();
            m_Duration = new TrapsDatabaseConn("Spikes").GETTrapDuration();
            m_Damage = new TrapsDatabaseConn("Spikes").GETTrapDamage();
            GetComponent<Collider2D>().enabled = false;
            
            Invoke("ActivateSpikes", timeToActivate);
        }

        private void ActivateSpikes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = m_Sprites[1];
            }
            GetComponent<Collider2D>().enabled = true;
            m_IsActive = true;
            Invoke("DisableSpikes", m_Duration);
        }

        private void DisableSpikes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = m_Sprites[0];
            }
            GetComponent<Collider2D>().enabled = false;
            m_IsActive = false;
            Invoke("ActivateSpikes", m_Cooldown);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && m_IsActive && Time.time >= m_NextDamage)
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(m_Damage);
                m_NextDamage = Time.time + m_Duration + 0.1f;
            }
        }
    }
}