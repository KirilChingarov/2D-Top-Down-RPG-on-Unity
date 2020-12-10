﻿using UnityEngine;
using Enums;

namespace Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        private bool isIdle = true;
        public Animator characterGFX;
        public Direction direction = Direction.IDLE;
    
        public void ChangeDirection(Direction direction){
            switch (direction)
            {
                case Direction.DOWN:
                    horizontalSpeed = 0f;
                    verticalSpeed = -1f;
                    isIdle = false;
                    break;
                case Direction.UP:
                    horizontalSpeed = 0f;
                    verticalSpeed = 1f;
                    isIdle = false;
                    break;
                case Direction.RIGHT:
                    horizontalSpeed = 1f;
                    verticalSpeed = 0f;
                    isIdle = false;
                    break;
                case Direction.LEFT:
                    horizontalSpeed = -1f;
                    verticalSpeed = 0f;
                    isIdle = false;
                    break;
                default:
                    horizontalSpeed = 0f;
                    verticalSpeed = 0f;
                    isIdle = true;
                    break;
            }
        
        
            characterGFX.SetFloat("HorizontalSpeed", horizontalSpeed);
            characterGFX.SetFloat("VerticalSpeed", verticalSpeed);
            characterGFX.SetBool("isIdle", isIdle);
        }

        // Update is called once per frame
        void Update()
        {
            ChangeDirection(direction);
        }
    }
}
