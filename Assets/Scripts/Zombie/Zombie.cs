using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Animator animator;
    [SerializeField] private float attackRange = 1.2f;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private int rotationSpeed = 200;
    
    

    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isDeathAnimationPlaying = false;
    [SerializeField] private GameObject _target;

    [SerializeField] public GameObject hand_R;

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
        
        yield return new WaitForSeconds(3);
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition - new Vector3(0f, 0.5f, 0f);

        float elapsedTime = 0f;
        float duration = 3f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        Destroy(gameObject);
    }

}