using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour
{
    [SerializeField] private LayerMask dashLayerMask;
    //public Touch touch1;
    private Rigidbody2D rigidbody2D;

    public float speedModifier;
    public Joystick joystick;
    private Vector3 moveDir;

    //public Animator animator;

    bool is_dashing = false;
    //

   // public GameObject  dashingPrefab;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 5.101f;
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = this.joystick.Horizontal;
        float verticalInput = this.joystick.Vertical;

        moveDir = new Vector3(horizontalInput,
                              verticalInput);

    }

    //for physics
    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir * speedModifier;

        //ROTATION
        if (moveDir != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
     
        //if(moveDir != Vector3.zero)
        //   transform.forward = moveDir;
        if (this.is_dashing)
        {
            //animator.SetTrigger("Dash");

            float dashAmount = 5f;

            //rigidbody2D.MovePosition(transform.position + moveDir * dashAmount);

            Vector3 dashPosition = transform.position + moveDir * dashAmount;


            /*float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            GameObject Dashing = Instantiate(dashingPrefab, transform.position + (transform.position - dashPosition)/2, Quaternion.AngleAxis(angle+90, Vector3.forward));
            */

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if(raycastHit2d.collider != null)
            {
                dashPosition = raycastHit2d.point;
            }
            rigidbody2D.MovePosition(dashPosition);


            this.is_dashing = false;
            //animator.SetTrigger("noDash");
           // Invoke("destroy_dash", 2f);
        }
    

    }
    /*void destroy_dash()
    {
        dashingPrefab.SetActive(false);
        //Destroy(dashingPrefab);
    }*/

    public bool get_is_dashing()
    {
        return is_dashing;
    }
    public void dash()
    {
        this.is_dashing = true;
    }
}

