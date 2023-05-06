using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
        var zombie_attack = other.gameObject.GetComponent<Zombie_Attack>();
        if (zombie_attack != null)
        {
            TakeDamage(zombie_attack.Damage);
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
        Destroy(gameObject);
    }
}