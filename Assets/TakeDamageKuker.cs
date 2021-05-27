using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageKuker : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeAmountOfDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Kuker is hurt!");
        //Play hurt animation
        //animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Die();
        }
    }

    void Die()
    {
            Debug.Log("Kuker died!");
            //Die animation
            //animator.SetBool("IsDead", true);
            //Disable enemy
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<move>().enabled = false;
            GetComponent<Shooting>().enabled = false;
            GetComponent<attack>().enabled = false;


            this.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
