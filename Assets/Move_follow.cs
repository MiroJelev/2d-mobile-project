using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_follow : MonoBehaviour
{

    [SerializeField] Transform player;
    private Vector3 moveDir;
    public Animator animator;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;


        float horizontalInput = this.joystick.Horizontal;
        float verticalInput = this.joystick.Vertical;

        moveDir = new Vector3(horizontalInput,
                              verticalInput);
        //moveDir = new Vector3(transform.position.x, transform.position.y);
        //moveDir = moveDir.normalized;
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }
}