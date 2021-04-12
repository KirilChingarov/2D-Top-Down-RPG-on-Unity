using UnityEngine;

namespace Combat.Abilities
{
    public class FireAttackAnimation : MonoBehaviour
    {
        private Animator fireVFX;

        public void Awake()
        {
            fireVFX = GetComponent<Animator>();
        }

        public void TriggerFireVFX()
        {
            fireVFX.SetTrigger("FireVFX");
        }
    }
}