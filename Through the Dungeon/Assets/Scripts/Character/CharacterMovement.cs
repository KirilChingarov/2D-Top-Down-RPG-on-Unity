using Enums;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private CharacterAnimationController characterGFX;

        public Direction getDirectionFromSpeed(float horizontalSpeed, float verticalSpeed)
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

        public Direction getDirectionFromVector(Vector2 distance)
        {
            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                if (distance.x > 0.01f) return Direction.RIGHT;
                if (distance.x < -0.01f) return Direction.LEFT;
                return Direction.IDLE;
            }
            else
            {
                if (distance.y > 0.01f) return Direction.UP;
                if (distance.y < -0.01f) return Direction.DOWN;
                return Direction.IDLE;
            }
        }

        public void setCharacterVelocity(Vector2 direction)
        {
            rb.velocity = direction;
        }

        public void setCharacterDirection(Direction direction)
        {
            characterGFX.changeDirection(direction);
        }

        public void setIsCharacterSwimming(bool isSwimming)
        {
            characterGFX.characterSwim(isSwimming);
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
