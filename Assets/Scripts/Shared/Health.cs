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
    // Start is called before the first frame update

    private void Awake()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Collision detected!");

        var zombie_attack = other.gameObject.GetComponent<Zombie_Attack>();
        if (zombie_attack != null)
        {
            TakeDamage(zombie_attack.Damage);
        }
        
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log("Collision detected!");
    //
    //     var bullet = collision.collider.GetComponent<Bullet>();
    //     if (bullet != null)
    //     {
    //         TakeDamage(bullet.Damage);
    //     }
    // }


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