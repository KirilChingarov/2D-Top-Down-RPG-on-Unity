using System;
using Character;
using Combat.Player;
using DatabasesScripts;
using Enemy;
using Enums;
using SaveScripts;
using UIScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement characterMovement;
        private PlayerDatabaseConn DBConn;
        private CharacterStats characterStats;
        private PlayerAttackController playerAttackController;
        private bool canMove = true;
        private bool m_IsSwimming = false;
        private float m_NextAttack = 0f;
        public HealthBar healthBar;
        private bool isDead = false;
        
        
        private float m_NextFireAttack = 0f;
        public AbilityUICooldownController fireCooldown;
        private float m_NextRangedAttack = 0f;
        public AbilityUICooldownController rangedCooldown;
        private float m_NextDefensiveAbility = 0f;
        public AbilityUICooldownController defensiveCooldown;
        private float m_NextHealingAbility = 0f;
        public AbilityUICooldownController healingCooldown;

        private GameStateController gameStateController;
        
        private void Awake()
        {
            gameStateController = GameObject.Find("GameStateController").GetComponent<GameStateController>().GetInstance();
            
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.SetRigidBody2D(GetComponent<Rigidbody2D>());
            characterMovement.SetCharacterAnimationController(GetComponentInChildren<CharacterAnimationController>());
            DBConn = new PlayerDatabaseConn();
            characterStats = new CharacterStats(DBConn);
            healthBar.SetMaxHealth(characterStats.GETHealth());
            
            SetUpPlayerAttackController();
            
            if (gameStateController != null && gameStateController.isLoadedFromSave)
            {
                characterStats.SetHealth(gameStateController.playerHealth);
                m_NextFireAttack = Time.time + gameStateController.fireCooldown;
                fireCooldown.StartCoroutine(fireCooldown.CooldownFillTime(gameStateController.fireCooldown));
                m_NextRangedAttack = Time.time + gameStateController.windCooldown;
                rangedCooldown.StartCoroutine(rangedCooldown.CooldownFillTime(gameStateController.windCooldown));
                m_NextDefensiveAbility = Time.time + gameStateController.earthCooldown;
                defensiveCooldown.StartCoroutine(defensiveCooldown.CooldownFillTime(gameStateController.earthCooldown));
                m_NextHealingAbility = Time.time + gameStateController.waterCooldown;
                healingCooldown.StartCoroutine(healingCooldown.CooldownFillTime(gameStateController.waterCooldown));
                healthBar.SetHealth(gameStateController.playerHealth);
            }
            if (gameStateController != null && gameStateController.isTransition)
            {
                characterStats.SetHealth(gameStateController.playerHealth);
                playerAttackController.setFireAttackDamage(gameStateController.fireDamage);
                playerAttackController.setRangedAttackDamage(gameStateController.windDamage);
                playerAttackController.setDefenseDamageReduction(gameStateController.earthDamageReduction);
                playerAttackController.setHealingAmount(gameStateController.waterHealingAmount);
                healthBar.SetHealth(gameStateController.playerHealth);
            }
            isDead = false;
        }

        private void FixedUpdate()
        {
            Move();
            if (!m_IsSwimming)
            {
                UseAttackAbilities();
                UseDefensiveAbilities();
            }
        }

        private void Move()
        {
            float horizontalSpeed = Input.GetAxisRaw("Horizontal");
            float verticalSpeed = Input.GetAxisRaw("Vertical");
            float moveSpeed = characterStats.GETMoveSpeed();
            Vector2 force;
            Direction direction;

            if(canMove){
                force = new Vector2(horizontalSpeed, verticalSpeed) * (moveSpeed * Time.deltaTime);
                direction = characterMovement.GETDirectionFromVector(force);
            }
            else
            {
                force = new Vector2(0f,0f);
                direction = Direction.Idle;
            }

            if (m_IsSwimming)
            {
                force.x = force.x * 0.7f;
                force.y = force.y * 0.7f;
            }
            
            characterMovement.SetCharacterVelocity(force);
            characterMovement.SetCharacterDirection(direction);
            characterMovement.SetIsCharacterSwimming(m_IsSwimming);
        }

        private void SetUpPlayerAttackController()
        {
            playerAttackController = GetComponentInChildren<PlayerAttackController>();
            playerAttackController.SetAttackRange(characterStats.GETAttackRange());
            playerAttackController.SetBasicAttackDamage(characterStats.GETAttackDamage());
            playerAttackController.SetUpFireAttack();
            fireCooldown.SetCooldown(playerAttackController.GETFireAttackCooldown());
            playerAttackController.SetUpRangedAttack();
            rangedCooldown.SetCooldown(playerAttackController.GETRangedAttackCooldown());
            playerAttackController.SetUpDefensiveAbility();
            defensiveCooldown.SetCooldown(playerAttackController.GETDefensiveAbilityCooldown());
            playerAttackController.SetUpHealingAbility();
            healingCooldown.SetCooldown(playerAttackController.GETHealingAbilityCooldown());
        }

        private void UseAttackAbilities()
        {
            if (Input.GetMouseButton(0) && Time.time >= m_NextAttack)
            {
                playerAttackController.Attack();
                m_NextAttack = Time.time + characterStats.GETAttackCooldown();
            }
            else if(Input.GetKey(playerAttackController.GETFireAttackKeyCode()) && Time.time >= m_NextFireAttack)
            {
                playerAttackController.FireAttack();
                m_NextFireAttack = Time.time + playerAttackController.GETFireAttackCooldown();
                fireCooldown.StartCoroutine("CooldownFill");
            }
            else if(Input.GetKey(playerAttackController.GETRangedAttackKeyCode()) && Time.time >= m_NextRangedAttack)
            {
                playerAttackController.RangedAttack();
                m_NextRangedAttack = Time.time + playerAttackController.GETRangedAttackCooldown();
                rangedCooldown.StartCoroutine("CooldownFill");
            }
        }

        private void UseDefensiveAbilities()
        {
            if (Input.GetKey(playerAttackController.GETDefensiveAbilityKeyCode()) && Time.time >= m_NextDefensiveAbility)
            {
                playerAttackController.DefensiveAbility();
                m_NextDefensiveAbility = Time.time + playerAttackController.GETDefensiveAbilityCooldown();
                defensiveCooldown.StartCoroutine("CooldownFill");
            }
            else if (Input.GetKey(playerAttackController.GETHealingAbilityKeyCode()) && Time.time >= m_NextHealingAbility)
            {
                playerAttackController.Heal();
                m_NextHealingAbility = Time.time + playerAttackController.GETHealingAbilityCooldown();
                healingCooldown.StartCoroutine("CooldownFill");
            }
        }

        public void BuffFireAttackDamage(float damage)
        {
            playerAttackController.BuffFireAttackDamage(damage);
        }

        public void BuffRangedAttackDamage(float damage)
        {
            playerAttackController.BuffRangedAttackDamage(damage);
        }

        public void BuffDefensiveAbilityDamageReduction(float amount)
        {
            playerAttackController.BuffDefensiveDamageReduction(amount);
        }

        public void BuffHealingAbilityAmount(float amount)
        {
            playerAttackController.BuffHealingAbilityAmount(amount);
        }

        public void FreezePosition()
        {
            canMove = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public void UnfreezePosition()
        {
            canMove = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void TakeDamage(float damage)
        {
            if (playerAttackController.IsDefensiveAbilityActive())
            {
                damage -= damage * (playerAttackController.GETDefensiveAbilityDmgReduction() / 100);
            }
            characterStats.TakeDamage(damage);
            healthBar.TakeDamage(damage);
            if (characterStats.GETHealth() <= Mathf.Epsilon && !isDead)
            {
                Debug.Log("Player Died");
                isDead = true;
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    if(enemy.GetComponent<EnemyController>() != null) enemy.GetComponent<EnemyController>().PlayerIsDead();
                    else enemy.GetComponent<DeathBossController>().PlayerIsDead();
                }
                Destroy(gameObject);
                SceneManager.LoadScene("Scenes/Menus/DeathScreen");
            }
        }

        public void HealPlayer()
        {
            float healingAmount = playerAttackController.GETHealingAmount();
            characterStats.Heal(healingAmount);
            healthBar.Heal(healingAmount);
        }

        public void SetIsSwimming(bool isCharacterSwimming)
        {
            m_IsSwimming = isCharacterSwimming;
        }
        
        public bool GETIsSwimming()
        {
            return m_IsSwimming;
        }

        public float GETPlayerHealth()
        {
            return characterStats.GETHealth();
        }

        public float getFireCooldown()
        {
            return m_NextFireAttack - Time.time;
        }

        public float getFireDamage()
        {
            return playerAttackController.getFireAttackDamage();
        }

        public float getWindCooldown()
        {
            return m_NextRangedAttack - Time.time;
        }

        public float getWindDamage()
        {
            return playerAttackController.getRangedAttackDamage();
        }

        public float getEarthCooldown()
        {
            return m_NextDefensiveAbility - Time.time;
        }

        public float getEarthDamageReduction()
        {
            return playerAttackController.getDefensiveDamageReduction();
        }

        public float getWaterCooldown()
        {
            return m_NextHealingAbility - Time.time;
        }

        public float getWaterHealingAmount()
        {
            return playerAttackController.GETHealingAmount();
        }
    }
}