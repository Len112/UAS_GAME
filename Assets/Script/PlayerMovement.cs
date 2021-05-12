using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;


    Rigidbody rb;
    public Transform playerRotate;
    Animator anim;
    private CharacterController controller;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());

        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(Attack2());

        }
    }

    void move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y > 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        if (isGrounded)
        {
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
             
                Jump();
            }
        }
        //playerRotate.localEulerAngles = new Vector3(0, moveX * 90, 0);
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    private void Idle()
    {
        anim.SetFloat("speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("speed", 1, 0.1f, Time.deltaTime);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    
    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 1);
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 0);
   

    }
    private IEnumerator Attack2()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 1);
        anim.SetTrigger("attack2");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 0);


    }

}
