using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class AbilityUICooldownController : MonoBehaviour
    {
        private float m_Cooldown;
        public Image fillImage;

        public void SetCooldown(float cooldown)
        {
            this.m_Cooldown = cooldown;
        }

        public IEnumerator CooldownFill()
        {
            fillImage.fillAmount = 0f;
            float startCooldownTime = Time.time;
            float endCooldownTime = Time.time + m_Cooldown;
            float fillAmount;

            while (Time.time < endCooldownTime)
            {
                fillAmount = MapFloat(Time.time, startCooldownTime, endCooldownTime, 0f, 1f);
                fillImage.fillAmount = fillAmount;
                yield return null;
            }
        }

        public float MapFloat(float value, float low1, float high1, float low2, float high2)
        {
            return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
        }
    }
}