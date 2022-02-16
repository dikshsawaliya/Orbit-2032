using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    
    [SerializeField] private int Health = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    
    [SerializeField] private Transform Cam;
     private float turnSmoothVelocity;
     private float turnSmoothTime = 0.1f;
        
    public float Jumpforce;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    //[SerializeField] private float jumpHeight;


    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentHealth = Health;
        healthBar.SetMaxHealth(Health);
    }

    private void Update()
    {
        Move();

       

    }

    private void Move()
    {

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }
        
        float moveZ = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        
       /* 

         moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0)* Vector3.forward;
            controller.Move(moveDir.normalized *  moveSpeed * Time.deltaTime);
        }*/
        
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);


        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Mouse0) )
            {
                anim.SetBool("FireProjectile",true);
            }

            if (!Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetBool("FireProjectile", false);
            }
            
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
        
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
                //anim.SetFloat("Jump", 0f);
            }
        
            else if (moveDirection == Vector3.zero)
            {
                Idle();
                //anim.SetFloat("Jump", 0f);
            }
            
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                anim.SetInteger("Jump", 1);
            }

           
            else //if (!Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("Jump", 0);
            }
        }
        
        controller.Move(moveDirection * Time.deltaTime);

       velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
        

    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f,0.1f , Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f,0.1f , Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed",1f, 0.1f , Time.deltaTime);
    }

    private void Jump()
    {
        //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        if (isGrounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, Jumpforce);
            isGrounded = false;
        }
       
       
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyProjectile")
        {
            StartCoroutine(hitAnim());
        }

        
        if (col.gameObject.tag != "EnemyProjectile")
        {
            
        }
        

        if (col.gameObject.tag == "DestroyObject")
        {
            Debug.Log("Collision Detected");
            Destroy(col.gameObject);
        }       
    }

    
    IEnumerator hitAnim()
    {
        anim.SetBool("Hit", true);
        takeDamage(5);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Hit", false);

    }
    
    public void takeDamage(int Damage)
    {
        
        currentHealth -= Damage;
        healthBar.Sethealth(currentHealth);
        
        if (currentHealth <=0)
        {
            Invoke(nameof(DestroyPlayer), 0.5f);
        }
    }
    
    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

   

    
}
