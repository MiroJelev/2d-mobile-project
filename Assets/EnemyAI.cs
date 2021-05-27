using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float shootRange;
    [SerializeField] float agroRange;
    [SerializeField] float melleRange;
    

    [SerializeField] float moveSpeed;

    private Vector3 moveDir;

    Rigidbody2D rb;

    //public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);
        //Debug.Log("Distance: " + distToPlayer);
        if (distToPlayer < melleRange)
        {
            StopChasingPlayer();
            MelleAttack();
        }
        else if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else if(distToPlayer < shootRange)
        {
            FaceTarget();
            GetComponent<Shooting>().shoot_click();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    void FaceTarget()
    {
        Vector3 targetdir = player.position - transform.position;
        float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void MelleAttack()
    {
        FaceTarget();
        
        //Debug.Log("Meellleee: ");
        GetComponent<attack>().attack_press();
        //animator.SetTrigger("Attack");

    }
    void ChasePlayer()
    {
        // Vector3 targetdir = player.position - transform.position;
        // float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg;
        //Debug.Log("angle: " + angle);
        //rb.rotation = angle;

        FaceTarget();
        Vector3 targetdir = player.position - transform.position;

        targetdir.Normalize();
        moveDir = targetdir;
        //shootPlayer
       
    }
    private void FixedUpdate()
    {
        move(moveDir);
    }
    void move(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed;     // *Time.deltaTime
        //rb.MovePosition((Vector3)transform.position + direction * moveSpeed/20f);
    }
    
    void StopChasingPlayer()
    {
        moveDir = new Vector3(0,0,0);
    }

}
