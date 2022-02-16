using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public Transform currentObject;
    public Transform goalObject;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float closeEnoughDistance = 2f;

    [SerializeField] private CharacterController controller; 


    private List<Enemy> otherEnemies = new List<Enemy>();

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        
        foreach (var enemy in GameObject.FindObjectsOfType<Enemy>())
        {
            if (enemy != this)
            {
                otherEnemies.Add(enemy);
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("Run", true);
        
        float distancetoGoal = Vector3.Distance(transform.position, goalObject.position);
        Vector3 goalDierction = (transform.position - goalObject.position).normalized;

        Vector3 lookAtGoal = new Vector3(goalObject.position.x, this.transform.position.y, goalObject.position.z);
        
        Debug.DrawLine(transform.position, lookAtGoal, Color.red, 0.01f, false);
        
        transform.LookAt(lookAtGoal);

        if (Mathf.Abs(distancetoGoal) > closeEnoughDistance)
        {
            transform.Translate((goalDierction * speed * Time.deltaTime));
        }

        foreach (var enemy in otherEnemies)
        {
            if (Vector3.Distance(transform.position, transform.position) > 2)
            {
                Vector3 oppEnemyDirection = (transform.position - enemy.transform.position).normalized;
                transform.Translate((oppEnemyDirection * speed * Time.deltaTime));
            }
        }
    }
    
    [Header("Gravity")]
    public Transform groundCheck;
    public LayerMask groundMask;
    public float gravity = -9.8f;
    public float groundDistance = 0.2f;

    private Vector3 velocity;
    private bool isGrounded;

    public void gravityAdd()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}