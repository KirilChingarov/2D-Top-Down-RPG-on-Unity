using System.Collections;
using System.Collections.Generic;
using Character;
using Player;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerController playerController;
    private CharacterAnimationController characterAnimationController;
    
    void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        characterAnimationController = GameObject.Find("CharacterGFX").GetComponent<CharacterAnimationController>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            characterAnimationController.attack();
        }
    }
}
