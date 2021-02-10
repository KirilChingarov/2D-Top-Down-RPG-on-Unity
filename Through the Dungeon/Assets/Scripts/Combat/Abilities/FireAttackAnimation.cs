using System;
using UnityEngine;

namespace Abilities
{
    public class FireAttackAnimation : MonoBehaviour
    {
        private Animator m_FireVFX;

        public void Awake()
        {
            m_FireVFX = GetComponent<Animator>();
        }

        public void TriggerFireVFX()
        {
            m_FireVFX.SetTrigger("FireVFX");
        }
    }
}