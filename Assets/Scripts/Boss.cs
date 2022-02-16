using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public GameObject TheDestination;
    private NavMeshAgent TheAgent;

    public Transform player;

    [SerializeField] private int Health = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBarBoss;
    
    public LayerMask wahtIsGround, whatIsPlayer;
    
    //Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;
    
    
    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject Projectile;
    
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
    //Animation
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        TheAgent = GetComponent<NavMeshAgent>();
        currentHealth = Health;
        healthBarBoss.SetMaxHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);

        TheAgent.SetDestination(TheDestination.transform.position);

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange) 
        {
            AttackPlayer();
            anim.SetBool("Run", false);
            anim.SetBool("Attack", true);
        }
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        TheAgent = GetComponent<NavMeshAgent>();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            TheAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = transform.position - walkPoint;
        
        //walkPoint reached

        if (distanceToWalkpoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, wahtIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        TheAgent.SetDestination(player.position);
    }
    
    private void AttackPlayer()
    {
        //making sure enemy is not moving 
        TheAgent.SetDestination(transform.position);
        
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack
            Rigidbody rb = Instantiate(Projectile, transform.position+ (transform.up * 1.5f) + (transform.forward * 1.5f), Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 8f, ForceMode.Impulse);
            
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
           
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            StartCoroutine(takeDamage());
            takeDamage(5);
        }
    }

    IEnumerator takeDamage()
    {
        anim.SetBool("Damage", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Damage", false);
        yield return 0;
        
    }

    public void takeDamage(int Damage)
    {
        
        currentHealth -= Damage;
        healthBarBoss.Sethealth(currentHealth);
        
        if (currentHealth <=0)
        {
           
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }
}
