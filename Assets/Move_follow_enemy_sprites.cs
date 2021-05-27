using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_follow_enemy_sprites : MonoBehaviour
{
    [SerializeField]
    Transform player;
    private Vector3 moveDir;
    public Animator animator;

    private Vector3 lastPos;
    private Vector3 res;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        transform.position = player.position;
    }
        // Update is called once per frame
        void FixedUpdate()
    {
       // Vector3 distance = transform.position - player.position;
        

        moveDir = new Vector3(transform.position.x, transform.position.y);
        res = moveDir - lastPos;
        res = res.normalized;


        //distance = distance.normalized;
        animator.SetFloat("Horizontal", res.x);
        //animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", res.sqrMagnitude);

        lastPos = moveDir;
    }
}
