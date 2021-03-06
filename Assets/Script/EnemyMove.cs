using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatisGround, WhatisPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timebetweenAttack;
    bool Alreadyattacked;

    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    public PlayerHealth playerhealth;
    public EnemyHealth enemyhealth;

    AudioSource roar;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        roar = GetComponentInChildren<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position,sightRange,WhatisPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatisPlayer);

        if (enemyhealth.CurrentHealth>0)
        {
            if (!playerInsightRange && !playerInAttackRange) patrolling();
            if (playerInsightRange && !playerInAttackRange) chaseplayer();
            if (playerInsightRange && playerInAttackRange) attackplayer();
        } 
        
        else if (playerhealth.CurrentHealth > 0)
        {
            if (!playerInsightRange && !playerInAttackRange) patrolling();
            if (playerInsightRange && !playerInAttackRange) chaseplayer();
            if (playerInsightRange && playerInAttackRange) attackplayer();
        }
        
    }

    public void patrolling()
    {

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            anim.SetBool("Walk", true);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x+randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,-transform.up,2f,WhatisGround))
        {
            walkPointSet = true;
        }
    }
    public void chaseplayer()
    {
        anim.SetBool("Walk", true);
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    public void attackplayer()
    {
        if (enemyhealth.CurrentHealth <= 0)
        {
            anim.SetTrigger("Die");
            roar.Stop();
        }
        else
        {
            agent.SetDestination(transform.position);

            transform.LookAt(player);

            anim.SetBool("Walk", false);
            if (playerhealth.CurrentHealth <= 0)
            {
                Alreadyattacked = true;
              
            }
            if (!Alreadyattacked)
            {
                anim.SetTrigger("Attack");
                roar.Play();
                Alreadyattacked = true;
                Invoke(nameof(ResetAttack), timebetweenAttack);
            }
        }

    }

    private void ResetAttack()
    {
        Alreadyattacked = false;
    }

   

}
