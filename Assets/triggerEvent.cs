using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEvent : MonoBehaviour
{
    public Collider2D m_ObjectCollider;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Debug.Log("TRIGERRRRactivate");
            m_ObjectCollider.isTrigger = false;

        }
        
    }
}
