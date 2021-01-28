using System;
using Character;
using DatabasesScripts;
using Enemy;
using Enums;
using UIScripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement characterMovement;
        private PlayerDatabaseConn dbConn;
        private CharacterStats characterStats;
        private PlayerAttackController playerAttackController;
        private bool canMove = true;
        private bool isSwimming = false;
        private float nextAttack = 0f;
        public HealthBar healthBar;
        
        
        private float nextFireAttack = 0f;
        public AbilityUICooldownController fireCooldown;
        private float nextRangedAttack = 0f;
        public AbilityUICooldownController rangedCooldown;
        private float nextDefensiveAbility = 0f;
        public AbilityUICooldownController defensiveCooldown;
        private float nextHealingAbility = 0f;
        public AbilityUICooldownController healingCooldown;
        
        private void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.setCharacterAnimationController(GetComponentInChildren<CharacterAnimationController>());
            dbConn = new PlayerDatabaseConn();
            characterStats = new CharacterStats(dbConn);
            healthBar.setMaxHealth(characterStats.getHealth());
            
            setUpPlayerAttackController();
        }

        private void FixedUpdate()
        {
            Move();
            Attack();
            if (!isSwimming)
            {
                useAttackAbilities();
                useDefensiveAbilities();
            }
        }

        private void Move()
        {
            float horizontalSpeed = Input.GetAxisRaw("Horizontal");
            float verticalSpeed = Input.GetAxisRaw("Vertical");
            float moveSpeed = characterStats.getMoveSpeed();
            Vector2 force;
            Direction direction;

            if(canMove){
                force = new Vector2(horizontalSpeed, verticalSpeed) * (moveSpeed * Time.deltaTime);
                direction = characterMovement.getDirectionFromVector(force);
            }
            else
            {
                force = new Vector2(0f,0f);
                direction = Direction.IDLE;
            }

            if (isSwimming)
            {
                force.x = force.x * 0.7f;
                force.y = force.y * 0.7f;
            }
            
            characterMovement.setCharacterVelocity(force);
            characterMovement.setCharacterDirection(direction);
            characterMovement.setIsCharacterSwimming(isSwimming);
        }

        private void Attack()
        {
            if (Input.GetMouseButton(0) && Time.time >= nextAttack)
            {
                playerAttackController.Attack();
                nextAttack = Time.time + characterStats.getAttackCooldown();
            }
        }

        private void setUpPlayerAttackController()
        {
            playerAttackController = GetComponentInChildren<PlayerAttackController>();
            playerAttackController.setAttackRange(characterStats.getAttackRange());
            playerAttackController.setBasicAttackDamage(characterStats.getAttackDamage());
            playerAttackController.setUpFireAttack();
            fireCooldown.setCooldown(playerAttackController.getFireAttackCooldown());
            playerAttackController.setUpRangedAttack();
            rangedCooldown.setCooldown(playerAttackController.getRangedAttackCooldown());
            playerAttackController.setUpDefensiveAbility();
            defensiveCooldown.setCooldown(playerAttackController.getDefensiveAbilityCooldown());
            playerAttackController.setUpHealingAbility();
            healingCooldown.setCooldown(playerAttackController.getHealingAbilityCooldown());
        }

        private void useAttackAbilities()
        {
            if(Input.GetKey(playerAttackController.getFireAttackKeyCode()) && Time.time >= nextFireAttack)
            {
                playerAttackController.FireAttack();
                nextFireAttack = Time.time + playerAttackController.getFireAttackCooldown();
                fireCooldown.StartCoroutine("cooldownFill");
            }
            else if(Input.GetKey(playerAttackController.getRangedAttackKeyCode()) && Time.time >= nextRangedAttack)
            {
                playerAttackController.RangedAttack();
                nextRangedAttack = Time.time + playerAttackController.getRangedAttackCooldown();
                rangedCooldown.StartCoroutine("cooldownFill");
            }
        }

        private void useDefensiveAbilities()
        {
            if (Input.GetKey(playerAttackController.getDefensiveAbilityKeyCode()) && Time.time >= nextDefensiveAbility)
            {
                playerAttackController.DefensiveAbility();
                nextDefensiveAbility = Time.time + playerAttackController.getDefensiveAbilityCooldown();
                defensiveCooldown.StartCoroutine("cooldownFill");
            }
            else if (Input.GetKey(playerAttackController.getHealingAbilityKeyCode()) && Time.time >= nextHealingAbility)
            {
                playerAttackController.Heal();
                nextHealingAbility = Time.time + playerAttackController.getHealingAbilityCooldown();
                healingCooldown.StartCoroutine("cooldownFill");
            }
        }

        public void freezePosition()
        {
            canMove = false;
        }

        public void unfreezePosition()
        {
            canMove = true;
        }

        public void takeDamage(float damage)
        {
            if (playerAttackController.isDefensiveAbilityActive())
            {
                damage -= damage * (playerAttackController.getDefensiveAbilityDmgReduction() / 100);
            }
            characterStats.takeDamage(damage);
            healthBar.takeDamage(damage);
            Debug.Log(this.gameObject.name + " health : " + characterStats.getHealth());
            if (characterStats.getHealth() == 0f)
            {
                Debug.Log("Player Died");
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyController>().playerIsDead();
                }
                Destroy(this.gameObject);
            }
        }

        public void healPlayer()
        {
            float healingAmount = playerAttackController.getHealingAmount();
            characterStats.heal(healingAmount);
            healthBar.Heal(healingAmount);
            Debug.Log(this.gameObject.name + "healed to health : " + characterStats.getHealth());
        }

        public void setIsSwimming(bool isCharacterSwimming)
        {
            isSwimming = isCharacterSwimming;
        }
        
        public bool getIsSwimming()
        {
            return isSwimming;
        }
        
    }
}