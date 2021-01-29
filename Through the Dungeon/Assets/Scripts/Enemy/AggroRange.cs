using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour
{
    private Collider2D m_Collider;
    private bool m_IsPlayerInAggroRange = false;
    
    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_IsPlayerInAggroRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_IsPlayerInAggroRange = false;
        }
    }

    public bool IsPlayerInAggroRange()
    {
        return m_IsPlayerInAggroRange;
    }
}
