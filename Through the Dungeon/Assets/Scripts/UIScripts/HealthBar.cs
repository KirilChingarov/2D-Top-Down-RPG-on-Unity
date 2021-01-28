using System;
using DatabasesScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthBar;

        private void Awake()
        {
            healthBar = GetComponent<Slider>();
        }

        public void setMaxHealth(float maxHealth)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }

        public void setCurrentHealth(float currentHealth)
        {
            healthBar.value = currentHealth;
        }

        public void takeDamage(float damage)
        {
            healthBar.value -= damage;
            if (healthBar.value <= 0f)
            {
                healthBar.value = 0f;
            }
        }

        public void Heal(float healingAmount)
        {
            healthBar.value += healingAmount;
            if (healthBar.value >= healthBar.maxValue)
            {
                healthBar.value = healthBar.maxValue;
            }
        }
    }
}