using Enums;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private CharacterAnimationController characterGFX;
        private Direction currDirection = Direction.IDLE;

        private Direction getDirectionFromSpeed(float horizontalSpeed, float verticalSpeed)
        {
            if (verticalSpeed > 0.01f)
            {
                return Direction.UP;
            }
            else if(verticalSpeed < -0.01f)
            {
                return Direction.DOWN;
            }
            else if (horizontalSpeed > 0.01f)
            {
                return Direction.RIGHT;
            }
            else if(horizontalSpeed < -0.01f)
            {
                return Direction.LEFT;
            }
            return Direction.IDLE;
        }

        public void setCharacterVelocity(float horizontalSpeed, float verticalSpeed, float moveSpeed)
        {
            rb.velocity = new Vector2(horizontalSpeed * moveSpeed, verticalSpeed * moveSpeed);
        
            currDirection = getDirectionFromSpeed(horizontalSpeed, verticalSpeed);
            characterGFX.ChangeDirection(currDirection);
        }

        public void setRigidBody2D(Rigidbody2D newRb)
        {
            rb = newRb;
        }

        public void setCharacterAnimationContrller(CharacterAnimationController newChAnimationControllerC)
        {
            characterGFX = newChAnimationControllerC;
        }
    }
}
