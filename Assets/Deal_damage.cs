using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deal_damage : MonoBehaviour
{
    public LayerMask Obsticles;

    //public GameObject hitEffect;
    public int attackDamage = 25;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Obsticles == (Obsticles | (1 << collision.gameObject.layer)))
        {
            if (collision.gameObject.layer == 7)
            {
                Debug.Log("stepped on death box " + collision.gameObject.name);
                collision.gameObject.GetComponent<TakeDamage>().TakeAmountOfDamage(attackDamage);
            }
            if (collision.gameObject.layer == 9)
            {
                Debug.Log("stepped on death box " + collision.gameObject.name);
                collision.gameObject.GetComponent<TakeDamageKuker>().TakeAmountOfDamage(attackDamage);
                
            }

            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);
            //Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

   
}
