using System;
using UnityEngine;

namespace Objects
{
    public class BossHealthBarEnabler : MonoBehaviour
    {
        public GameObject bossHealthBar;
        public void Awake()
        {
            bossHealthBar.SetActive(true);
            Destroy(gameObject);
        }
    }
}