using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Sound : MonoBehaviour
{
    [SerializeField] public AudioClip moveSound;
    [SerializeField] public AudioClip deathSound;
    [SerializeField] public AudioClip attackSound;

    private Animator animator;
    private AudioSource audioSource;

    private bool isDying = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        audioSource.spatialBlend = 1f; 
        audioSource.minDistance = 1f; 
        audioSource.maxDistance = 15f; 
        audioSource.volume = 0.3f;

    }

    IEnumerator PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
    }

    void Update()
    {
        bool currentIsDead = animator.GetBool("isDying");
        if (currentIsDead && !isDying)
        {
            StartCoroutine(PlaySound(deathSound));
            isDying = true;
            return;
        }

        bool currentIsMoving = animator.GetBool("isMoving");
        bool currentIsAttacking = animator.GetBool("isAttacking");

        if (currentIsMoving && !isDying && !audioSource.isPlaying)
        {
            StartCoroutine(PlaySound(moveSound));
        }

        if (currentIsAttacking && !isDying && !audioSource.isPlaying)
        {
            StartCoroutine(PlaySound(attackSound));
        }
    }
}