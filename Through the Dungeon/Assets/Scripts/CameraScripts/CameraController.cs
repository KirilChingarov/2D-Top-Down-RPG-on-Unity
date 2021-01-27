using System;
using UnityEngine;

namespace CameraScripts
{
    public class CameraController : MonoBehaviour
    {
        private Transform target;
        private float horizontalDiviation = 1.5f;
        private float verticalDiviation = 1.5f;

        public void Awake()
        {
            target = GameObject.Find("PlayerCharacter").transform;
        }

        public void FixedUpdate()
        {
            float newPositionX = transform.position.x;
            float newPositionY = transform.position.y;
            float moveDistance;
            
            if (Math.Abs(target.position.x - transform.position.x) >= horizontalDiviation)
            {
                moveDistance = Math.Abs(target.position.x - transform.position.x) - horizontalDiviation;
                if (target.position.x > transform.position.x)
                {
                    newPositionX = transform.position.x + moveDistance;
                }
                else
                {
                    newPositionX = transform.position.x - moveDistance;
                }
            }
            if (Math.Abs(target.position.y - transform.position.y) >= verticalDiviation)
            {
                moveDistance = Math.Abs(target.position.y - transform.position.y) - verticalDiviation;
                if (target.position.y > transform.position.y)
                {
                    newPositionY = transform.position.y + moveDistance;
                }
                else
                {
                    newPositionY = transform.position.y - moveDistance;
                }
            }
            
            transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
        }
    }
}