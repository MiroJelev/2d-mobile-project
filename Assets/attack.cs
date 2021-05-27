using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    //public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;
    bool is_attacking = false;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (is_attacking && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Attack();
            is_attacking = false;
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        //center  radius  which layers to detect
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemyLayers == (enemyLayers | (1 << enemy.gameObject.layer)))
            {
                if (enemy.gameObject.layer == 9)
                {
                    Debug.Log("Kuker hit " + enemy.name);
                    enemy.GetComponent<TakeDamageKuker>().TakeAmountOfDamage(attackDamage);
                }
                if (enemy.gameObject.layer == 7)
                {
                    Debug.Log("We hit " + enemy.name);
                    enemy.GetComponent<TakeDamage>().TakeAmountOfDamage(attackDamage);
                }
            }
           
        }
        
    }
    public void attack_press()
    {
        is_attacking = true;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
