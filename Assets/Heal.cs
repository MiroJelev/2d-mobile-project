using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int HealAmount = 25;
    public Collider2D TargetHeal;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("stepped on KISELO MLQKO ");
        TargetHeal = collider;
        HealTarget();
    }

    public void HealTarget()
    {
        HealAmount = -HealAmount;
        if (TargetHeal.gameObject.layer == 9)
        {
            TargetHeal.gameObject.GetComponent<TakeDamageKuker>().TakeAmountOfDamage(HealAmount);
        }
    }

}
