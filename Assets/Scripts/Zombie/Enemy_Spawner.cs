using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array of enemy prefabs to spawn
    public Transform spawnPoint;  // Spawn point for enemies
    public float spawnDelay = 2f;  // Delay between enemy spawns
    public int maxEnemies = 10;  // Maximum number of enemies to spawn

    private int _enemyCount = 0;  // Current number of spawned enemies
    public RuntimeAnimatorController animatorController;

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn enemies
    IEnumerator SpawnEnemies()
    {
        while (_enemyCount < maxEnemies)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        
            // Add a NavMeshAgent component to the enemy
            NavMeshAgent agent = enemy.AddComponent<NavMeshAgent>();
        
            _enemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}