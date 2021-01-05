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

        public void setCharacterVelocity(Vector2 direction)
        {
            rb.velocity = direction;
        
            currDirection = getDirectionFromSpeed(direction.x, direction.y);
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

        public Vector2 getCurrentPosition()
        {
            return rb.position;
        }
    }
}
