using System;
using UnityEngine;

namespace CameraScripts
{
    public class CameraController : MonoBehaviour
    {
        private Transform m_Target;
        private float m_HorizontalDiviation = 1.5f;
        private float m_VerticalDiviation = 1.5f;

        public void Awake()
        {
            m_Target = GameObject.Find("PlayerCharacter").transform;
        }

        public void FixedUpdate()
        {
            float newPositionX = transform.position.x;
            float newPositionY = transform.position.y;
            float moveDistance;
            
            if (Math.Abs(m_Target.position.x - transform.position.x) >= m_HorizontalDiviation)
            {
                moveDistance = Math.Abs(m_Target.position.x - transform.position.x) - m_HorizontalDiviation;
                if (m_Target.position.x > transform.position.x)
                {
                    newPositionX = transform.position.x + moveDistance;
                }
                else
                {
                    newPositionX = transform.position.x - moveDistance;
                }
            }
            if (Math.Abs(m_Target.position.y - transform.position.y) >= m_VerticalDiviation)
            {
                moveDistance = Math.Abs(m_Target.position.y - transform.position.y) - m_VerticalDiviation;
                if (m_Target.position.y > transform.position.y)
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