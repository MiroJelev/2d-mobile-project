using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDissappear : MonoBehaviour
{
    public Collider2D m_ObjectCollider;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Debug.Log("TRIGERRRRDestroy");
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(m_ObjectCollider);

        }

    }
}
