﻿using Enums;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody2D m_Rb;
        private CharacterAnimationController m_CharacterGfx;

        public Direction GETDirectionFromSpeed(float horizontalSpeed, float verticalSpeed)
        {
            if (verticalSpeed > 0.01f)
            {
                return Direction.Up;
            }
            else if(verticalSpeed < -0.01f)
            {
                return Direction.Down;
            }
            else if (horizontalSpeed > 0.01f)
            {
                return Direction.Right;
            }
            else if(horizontalSpeed < -0.01f)
            {
                return Direction.Left;
            }
            return Direction.Idle;
        }

        public Direction GETDirectionFromVector(Vector2 distance)
        {
            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                if (distance.x > 0.01f) return Direction.Right;
                if (distance.x < -0.01f) return Direction.Left;
                return Direction.Idle;
            }
            else
            {
                if (distance.y > 0.01f) return Direction.Up;
                if (distance.y < -0.01f) return Direction.Down;
                return Direction.Idle;
            }
        }

        public void SetCharacterVelocity(Vector2 direction)
        {
            m_Rb.velocity = direction;
        }

        public void SetCharacterDirection(Direction direction)
        {
            m_CharacterGfx.ChangeDirection(direction);
        }

        public void SetIsCharacterSwimming(bool isSwimming)
        {
            m_CharacterGfx.CharacterSwim(isSwimming);
        }

        public void SetRigidBody2D(Rigidbody2D newRb)
        {
            m_Rb = newRb;
        }

        public void SetCharacterAnimationController(CharacterAnimationController newChAnimationControllerC)
        {
            m_CharacterGfx = newChAnimationControllerC;
        }

        public Vector2 GETCurrentPosition()
        {
            return m_Rb.position;
        }

        public void CharacterDeath()
        {
            m_CharacterGfx.CharacterDeath();
        }
    }
}
