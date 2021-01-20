using System;
using UnityEngine;

namespace Abilities
{
    public class FireAttackAnimation : MonoBehaviour
    {
        private Animator fireVFX;

        public void Awake()
        {
            fireVFX = GetComponent<Animator>();
        }

        public void triggerFireVFX()
        {
            fireVFX.SetTrigger("FireVFX");
        }
    }
}