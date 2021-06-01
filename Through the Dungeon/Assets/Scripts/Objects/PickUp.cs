using System;
using Enums;
using Player;
using UnityEngine;

namespace Objects
{
    public class PickUp : MonoBehaviour
    {
        public float buffAmount = 0f;
        public AbilityName targetAbility;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                switch (targetAbility)
                {
                    case AbilityName.FireAttack:
                        BuffFireAttack(other);
                        break;
                    case AbilityName.RangedAttack:
                        BuffRangedAttack(other);
                        break;
                    case AbilityName.DefensiveAbility:
                        BuffDefensiveAbility(other);
                        break;
                    case AbilityName.HealingAbility:
                        BuffHealingAbility(other);
                        break;
                }
            }
        }

        private void BuffFireAttack(Collider2D other)
        {
            other.gameObject.GetComponent<PlayerController>().BuffFireAttackDamage(buffAmount);
            Destroy(gameObject);
        }

        private void BuffRangedAttack(Collider2D other)
        {
            other.gameObject.GetComponent<PlayerController>().BuffRangedAttackDamage(buffAmount);
            Destroy(gameObject);
        }

        private void BuffDefensiveAbility(Collider2D other)
        {
            other.gameObject.GetComponent<PlayerController>().BuffDefensiveAbilityDamageReduction(buffAmount);
            Destroy(gameObject);
        }

        private void BuffHealingAbility(Collider2D other)
        {
            other.gameObject.GetComponent<PlayerController>().BuffHealingAbilityAmount(buffAmount);
            Destroy(gameObject);
        }
    }
}