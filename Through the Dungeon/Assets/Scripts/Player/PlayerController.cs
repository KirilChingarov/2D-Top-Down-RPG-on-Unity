﻿using System;
using Character;
using DatabasesScripts;
using Enemy;
using Enums;
using SaveScripts;
using UIScripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement m_CharacterMovement;
        private PlayerDatabaseConn m_DBConn;
        private CharacterStats m_CharacterStats;
        private PlayerAttackController m_PlayerAttackController;
        private bool m_CanMove = true;
        private bool m_IsSwimming = false;
        private float m_NextAttack = 0f;
        public HealthBar healthBar;
        
        
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
            
            m_CharacterMovement = GetComponent<CharacterMovement>();
            m_CharacterMovement.SetRigidBody2D(GetComponent<Rigidbody2D>());
            m_CharacterMovement.SetCharacterAnimationController(GetComponentInChildren<CharacterAnimationController>());
            m_DBConn = new PlayerDatabaseConn();
            m_CharacterStats = new CharacterStats(m_DBConn);
            healthBar.SetMaxHealth(m_CharacterStats.GETHealth());
            
            SetUpPlayerAttackController();
            
            if (gameStateController != null && gameStateController.isLoadedFromSave)
            {
                m_CharacterStats.SetHealth(gameStateController.playerHealth);
                m_NextFireAttack = Time.time + gameStateController.fireCooldown;
                fireCooldown.StartCoroutine(fireCooldown.CooldownFillTime(gameStateController.fireCooldown));
                m_NextRangedAttack = Time.time + gameStateController.windCooldown;
                rangedCooldown.StartCoroutine(rangedCooldown.CooldownFillTime(gameStateController.windCooldown));
                m_NextDefensiveAbility = Time.time + gameStateController.earthCooldown;
                defensiveCooldown.StartCoroutine(defensiveCooldown.CooldownFillTime(gameStateController.earthCooldown));
                m_NextHealingAbility = Time.time + gameStateController.waterCooldown;
                healingCooldown.StartCoroutine(healingCooldown.CooldownFillTime(gameStateController.waterCooldown));
            }
            if (gameStateController != null && gameStateController.isTransition)
            {
                m_CharacterStats.SetHealth(gameStateController.playerHealth);
                m_PlayerAttackController.setFireAttackDamage(gameStateController.fireDamage);
                m_PlayerAttackController.setRangedAttackDamage(gameStateController.windDamage);
                m_PlayerAttackController.setDefenseDamageReduction(gameStateController.earthDamageReduction);
                m_PlayerAttackController.setHealingAmount(gameStateController.waterHealingAmount);
            }
            healthBar.SetHealth(gameStateController.playerHealth);
        }

        private void FixedUpdate()
        {
            Move();
            if (!m_IsSwimming)
            {
                Attack();
                UseAttackAbilities();
                UseDefensiveAbilities();
            }
        }

        private void Move()
        {
            float horizontalSpeed = Input.GetAxisRaw("Horizontal");
            float verticalSpeed = Input.GetAxisRaw("Vertical");
            float moveSpeed = m_CharacterStats.GETMoveSpeed();
            Vector2 force;
            Direction direction;

            if(m_CanMove){
                force = new Vector2(horizontalSpeed, verticalSpeed) * (moveSpeed * Time.deltaTime);
                direction = m_CharacterMovement.GETDirectionFromVector(force);
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
            
            m_CharacterMovement.SetCharacterVelocity(force);
            m_CharacterMovement.SetCharacterDirection(direction);
            m_CharacterMovement.SetIsCharacterSwimming(m_IsSwimming);
        }

        private void Attack()
        {
            if (Input.GetMouseButton(0) && Time.time >= m_NextAttack)
            {
                m_PlayerAttackController.Attack();
                m_NextAttack = Time.time + m_CharacterStats.GETAttackCooldown();
            }
        }

        private void SetUpPlayerAttackController()
        {
            m_PlayerAttackController = GetComponentInChildren<PlayerAttackController>();
            m_PlayerAttackController.SetAttackRange(m_CharacterStats.GETAttackRange());
            m_PlayerAttackController.SetBasicAttackDamage(m_CharacterStats.GETAttackDamage());
            m_PlayerAttackController.SetUpFireAttack();
            fireCooldown.SetCooldown(m_PlayerAttackController.GETFireAttackCooldown());
            m_PlayerAttackController.SetUpRangedAttack();
            rangedCooldown.SetCooldown(m_PlayerAttackController.GETRangedAttackCooldown());
            m_PlayerAttackController.SetUpDefensiveAbility();
            defensiveCooldown.SetCooldown(m_PlayerAttackController.GETDefensiveAbilityCooldown());
            m_PlayerAttackController.SetUpHealingAbility();
            healingCooldown.SetCooldown(m_PlayerAttackController.GETHealingAbilityCooldown());
        }

        private void UseAttackAbilities()
        {
            if(Input.GetKey(m_PlayerAttackController.GETFireAttackKeyCode()) && Time.time >= m_NextFireAttack)
            {
                m_PlayerAttackController.FireAttack();
                m_NextFireAttack = Time.time + m_PlayerAttackController.GETFireAttackCooldown();
                fireCooldown.StartCoroutine("CooldownFill");
            }
            else if(Input.GetKey(m_PlayerAttackController.GETRangedAttackKeyCode()) && Time.time >= m_NextRangedAttack)
            {
                m_PlayerAttackController.RangedAttack();
                m_NextRangedAttack = Time.time + m_PlayerAttackController.GETRangedAttackCooldown();
                rangedCooldown.StartCoroutine("CooldownFill");
            }
        }

        private void UseDefensiveAbilities()
        {
            if (Input.GetKey(m_PlayerAttackController.GETDefensiveAbilityKeyCode()) && Time.time >= m_NextDefensiveAbility)
            {
                m_PlayerAttackController.DefensiveAbility();
                m_NextDefensiveAbility = Time.time + m_PlayerAttackController.GETDefensiveAbilityCooldown();
                defensiveCooldown.StartCoroutine("CooldownFill");
            }
            else if (Input.GetKey(m_PlayerAttackController.GETHealingAbilityKeyCode()) && Time.time >= m_NextHealingAbility)
            {
                m_PlayerAttackController.Heal();
                m_NextHealingAbility = Time.time + m_PlayerAttackController.GETHealingAbilityCooldown();
                healingCooldown.StartCoroutine("CooldownFill");
            }
        }

        public void BuffFireAttackDamage(float damage)
        {
            m_PlayerAttackController.BuffFireAttackDamage(damage);
        }

        public void BuffRangedAttackDamage(float damage)
        {
            m_PlayerAttackController.BuffRangedAttackDamage(damage);
        }

        public void BuffDefensiveAbilityDamageReduction(float amount)
        {
            m_PlayerAttackController.BuffDefensiveDamageReduction(amount);
        }

        public void BuffHealingAbilityAmount(float amount)
        {
            m_PlayerAttackController.BuffHealingAbilityAmount(amount);
        }

        public void FreezePosition()
        {
            m_CanMove = false;
        }

        public void UnfreezePosition()
        {
            m_CanMove = true;
        }

        public void TakeDamage(float damage)
        {
            if (m_PlayerAttackController.IsDefensiveAbilityActive())
            {
                damage -= damage * (m_PlayerAttackController.GETDefensiveAbilityDmgReduction() / 100);
            }
            m_CharacterStats.TakeDamage(damage);
            healthBar.TakeDamage(damage);
            Debug.Log("Damage to Player: " + damage);
            Debug.Log(this.gameObject.name + " health : " + m_CharacterStats.GETHealth());
            if (m_CharacterStats.GETHealth() == 0f)
            {
                Debug.Log("Player Died");
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyController>().PlayerIsDead();
                }
                Destroy(this.gameObject);
            }
        }

        public void HealPlayer()
        {
            float healingAmount = m_PlayerAttackController.GETHealingAmount();
            m_CharacterStats.Heal(healingAmount);
            healthBar.Heal(healingAmount);
            Debug.Log(this.gameObject.name + "healed to health : " + m_CharacterStats.GETHealth());
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
            return m_CharacterStats.GETHealth();
        }

        public float getFireCooldown()
        {
            return m_NextFireAttack - Time.time;
        }

        public float getFireDamage()
        {
            return m_PlayerAttackController.getFireAttackDamage();
        }

        public float getWindCooldown()
        {
            return m_NextRangedAttack - Time.time;
        }

        public float getWindDamage()
        {
            return m_PlayerAttackController.getRangedAttackDamage();
        }

        public float getEarthCooldown()
        {
            return m_NextDefensiveAbility - Time.time;
        }

        public float getEarthDamageReduction()
        {
            return m_PlayerAttackController.getDefensiveDamageReduction();
        }

        public float getWaterCooldown()
        {
            return m_NextHealingAbility - Time.time;
        }

        public float getWaterHealingAmount()
        {
            return m_PlayerAttackController.GETHealingAmount();
        }
    }
}