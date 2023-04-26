using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Health : MonoBehaviour
{

    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int health;

    public event Action onDie = delegate {};

    private void Awake()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        
            Debug.Log("Collision detected!");

            var bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.Damage);
            }
        
    }


    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        onDie();
    }
}