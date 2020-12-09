using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public float horizontalSpeed = 0f;
    public float verticalSpeed = 0f;
    public bool isIdle = true;
    public Animator characterGFX;
    public int direction = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case 1:
                horizontalSpeed = 0f;
                verticalSpeed = -1f;
                isIdle = false;
                break;
            case 2:
                horizontalSpeed = 0f;
                verticalSpeed = 1f;
                isIdle = false;
                break;
            case 3:
                horizontalSpeed = 1f;
                verticalSpeed = 0f;
                isIdle = false;
                break;
            case 4:
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
}
