using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterHealth : MonoBehaviour
{
    public int maxHealth = 100;

    public Animator animator;
    public int health;
    public bool isDeadCharacter = false;
    public event Action onDie = delegate {};

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Awake()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("Collision detected!");

        var zombie_attack = other.gameObject.GetComponent<Zombie_Attack>();
        if (zombie_attack != null)
        {
            TakeDamage(zombie_attack.Damage);
        }
        
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isDeadCharacter)
        {
            isDeadCharacter = true;
            Die();
            animator.SetBool("isDeadCharacter", true);
            Invoke("LoadMainMenu", 1f);
        }
    }

    private void Die()
    {
        onDie();
    }
    
    public void LoadMainMenu()
    {
        animator.SetBool("isDeadCharacter", false);
        Invoke("LoadMainMenuDelayed", 5f);
    }

    private void LoadMainMenuDelayed()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main_Menu");
    }
}
