using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class BossHealthBar : HealthBar
    {
        public CanvasGroup canvasGroup;
        public RectTransform transform;
        public float timeUntilFull;
        public void Awake()
        {
            StartCoroutine(showHealthbar());
        }

        private IEnumerator showHealthbar()
        {
            float startTime = Time.time;
            float endTime = Time.time + timeUntilFull;

            canvasGroup.alpha = 0;
            transform.sizeDelta = new Vector2(0, 0);
            
            while (Time.time < endTime)
            {
                canvasGroup.alpha = MapFloat(Time.time, startTime, endTime, 0f, 1f);
                transform.sizeDelta = new Vector2(MapFloat(Time.time, startTime, endTime, 0f, 1200f), 
                    MapFloat(Time.time, startTime, endTime, 0f, 50f));
                yield return null;
            }

            canvasGroup.alpha = 1;
            Destroy(canvasGroup);
        }
        
        private float MapFloat(float value, float low1, float high1, float low2, float high2)
        {
            return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
        }
    }
}