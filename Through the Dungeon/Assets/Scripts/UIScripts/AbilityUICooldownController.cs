using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class AbilityUICooldownController : MonoBehaviour
    {
        private float cooldown;
        public Image fillImage;

        public void SetCooldown(float cooldown)
        {
            this.cooldown = cooldown;
        }

        public IEnumerator CooldownFill()
        {
            fillImage.fillAmount = 0f;
            float startCooldownTime = Time.time;
            float endCooldownTime = Time.time + cooldown;

            while (Time.time < endCooldownTime)
            {
                float fillAmount = MapFloat(Time.time, startCooldownTime, endCooldownTime, 0f, 1f);
                fillImage.fillAmount = fillAmount;
                yield return null;
            }
        }

        public IEnumerator CooldownFillTime(float targetCooldown)
        {
            float startCooldownTime = Time.time - (cooldown - targetCooldown);
            float endCooldownTime = Time.time + targetCooldown;
            fillImage.fillAmount = MapFloat(Time.time, startCooldownTime, endCooldownTime, 0f, 1f);
            
            while (Time.time < endCooldownTime)
            {
                float fillAmount = MapFloat(Time.time, startCooldownTime, endCooldownTime, 0f, 1f);
                fillImage.fillAmount = fillAmount;
                yield return null;
            }
        }

        private float MapFloat(float value, float low1, float high1, float low2, float high2)
        {
            return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
        }
    }
}