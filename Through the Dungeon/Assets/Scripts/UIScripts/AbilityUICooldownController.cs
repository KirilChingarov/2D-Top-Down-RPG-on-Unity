using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class AbilityUICooldownController : MonoBehaviour
    {
        private float cooldown;
        public Image fillImage;

        public void setCooldown(float cooldown)
        {
            this.cooldown = cooldown;
        }

        public IEnumerator cooldownFill()
        {
            fillImage.fillAmount = 0f;
            float startCooldownTime = Time.time;
            float endCooldownTime = Time.time + cooldown;
            float fillAmount;

            while (Time.time < endCooldownTime)
            {
                fillAmount = mapFloat(Time.time, startCooldownTime, endCooldownTime, 0f, 1f);
                fillImage.fillAmount = fillAmount;
                yield return null;
            }
        }

        public float mapFloat(float value, float low1, float high1, float low2, float high2)
        {
            return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
        }
    }
}