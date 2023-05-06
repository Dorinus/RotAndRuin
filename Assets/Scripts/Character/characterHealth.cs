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
			//Set animator to death animation
            animator.SetBool("isDeadCharacter", true);
			//Load Main menu function after 1 second to give time to animator to see the new state
            Invoke("LoadMainMenu", 1f);
        }
    }

    private void Die()
    {
        onDie();
    }
    
    public void LoadMainMenu()
    {
		//Set animator death state to false to prevent loop hell
        animator.SetBool("isDeadCharacter", false);
		//Load Main menu after 5 seconds
        Invoke("LoadMainMenuDelayed", 5f);
    }

    private void LoadMainMenuDelayed()
    {
		//Load main menu
        SceneManager.LoadScene("Main_Menu");
    }
}
