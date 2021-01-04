using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Enemy
{
    
    public class EnemyController : MonoBehaviour
    {
        private float horizontalSpeed = 0f;
        private float verticalSpeed = 0f;
        public float moveSpeed = 1f;
        private CharacterMovement characterMovement;
        
        // Start is called before the first frame update
        void Start()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterMovement.setRigidBody2D(GetComponent<Rigidbody2D>());
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

}