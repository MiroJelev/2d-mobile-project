using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    //public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    public Score score;
    public float points;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeAmountOfDamage(int damage)
    {
        currentHealth -= damage;
        //Play hurt animation
        //animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //Die animation
        //animator.SetBool("IsDead", true);
        //Disable enemy
        if(this.name == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("KarakondjulKill");
        }
        if(this.name == "Talasum")
        {
            FindObjectOfType<AudioManager>().Play("GhostKill");
        }
        if(this.name == "Bai-Ganyo")
        {
            FindObjectOfType<AudioManager>().Play("BaiGanioKill");
        }


        GetComponent<Heal>().HealTarget();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;

        score.AddScore(points);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
