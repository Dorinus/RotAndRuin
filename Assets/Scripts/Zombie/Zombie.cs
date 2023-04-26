using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator animator;
    public  float attackRange  = 1.2f;
    public float movementSpeed = 5.0f;
    public int rotationSpeed = 200;

    private bool isDead = false;
    private bool isDeathAnimationPlaying = false;
    private GameObject _target;
    
    
    //test
    public GameObject hand_R;

    private void Awake()
    {
        if (GetComponent<Zombie_Health>() != null)
        {
            GetComponent<Zombie_Health>().onDie += HandleDeath;
        }
    }
    
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        agent.updatePosition = false;
        agent.speed = movementSpeed;
        agent.angularSpeed = rotationSpeed;
        
        StartCoroutine(MoveToTarget());

    }


    IEnumerator MoveToTarget()
    {
        while (!isDead)
        {
            bool shouldMove = !animator.GetBool("isDying") && 
                              Vector3.Distance(transform.position, _target.transform.position) > attackRange;

            animator.SetBool("isMoving", shouldMove);
            animator.SetBool("isAttacking", !shouldMove);

            agent.destination = shouldMove ? _target.transform.position : transform.position;

            yield return null;
        }
    }

    
    private void OnAnimatorMove()
    {
        if (isDeathAnimationPlaying)
        {
             transform.position = animator.rootPosition;
        }
        else
        {
            transform.position = agent.nextPosition;
        }
    }
    
    private void HandleDeath()
    {
        isDead = true;
        isDeathAnimationPlaying = true;
        animator.SetBool("isDying", true);
        agent.updateRotation = false;
        // agent.enabled = false;
        StartCoroutine(DestroyAfterDelay(3f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
       
    }


}