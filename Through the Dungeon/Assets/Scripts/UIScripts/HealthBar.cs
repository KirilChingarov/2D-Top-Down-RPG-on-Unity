using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthBar;
        public Color32 flashColor;
        public Color32 baseColor;

        public void SetHealth(float health)
        {
            healthBar.value = health;
        }

        public void SetMaxHealth(float maxHealth)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            float targethealth = healthBar.value - damage;
            if (targethealth <= 0f) targethealth = 0f;    

            StartCoroutine(FlashHealthBar(targethealth));
        }

        private IEnumerator FlashHealthBar(float targetValue)
        {
            Image fillImage = healthBar.transform.Find("Fill").GetComponent<Image>();

            fillImage.color = flashColor;
            yield return new WaitForSeconds(0.2f);

            healthBar.value = targetValue;
            fillImage.color = baseColor;
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