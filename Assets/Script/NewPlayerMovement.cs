using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    public LayerMask layerMask;

    public bool Grounded;
  
    public float jumpForce =5;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public AudioSource walkaudio;
    public AudioSource walkaudio2;
    public AudioSource runaudio;
    public AudioSource swordaudio;

    private Vector3 movePos;

    public GameObject PauseCanvas;

    public NewPlayerLook Mouse;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        if (PlayerPrefs.HasKey("PosX") && PlayerPrefs.HasKey("PosY") && PlayerPrefs.HasKey("PosZ"))
        {
            float posx = PlayerPrefs.GetFloat("PosX");
            float posy = PlayerPrefs.GetFloat("PosY");
            float posz = PlayerPrefs.GetFloat("PosZ");
            transform.position = new Vector3(posx, posy, posz);
        }
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
            StartCoroutine(Defend());
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
            Mouse.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void move()
    {
       
        //input
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //isgroundcheck
        Grounded = Physics.CheckSphere(transform.position, 0.2f, layerMask);
        if (Grounded)
        {
            //move
            movePos = transform.right * x + transform.forward * z;

            if (movePos != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            if (movePos != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }

            if (movePos == Vector3.zero)
            {
                Idle();
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            {
                Jump();
            }
        }
       
        Vector3 newmovePos = new Vector3(movePos.x * moveSpeed, rb.velocity.y, movePos.z * moveSpeed);
        rb.velocity = newmovePos;
    }

    private void Idle()
    {
        anim.SetFloat("speed", 0, 0.1f, Time.deltaTime);
        walkaudio.Stop();
        runaudio.Stop();
        walkaudio2.Stop();
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
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

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 1);
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.6f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 0);
    }

    private IEnumerator Attack2()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 1);
        anim.SetTrigger("attack2");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 0);


    }

    private IEnumerator Defend()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 1);
        anim.SetTrigger("defend");
        yield return new WaitForSeconds(1f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack_Layer"), 0);
    }
}
