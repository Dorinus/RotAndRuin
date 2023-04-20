using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array of enemy prefabs to spawn
    public Transform spawnPoint;  // Spawn point for enemies
    public float spawnDelay = 2f;  // Delay between enemy spawns
    public int maxEnemies = 3;  // Maximum number of enemies to spawn
    // public System.Type[] scriptsList; // Scripts to attach to zombie prefabs
    private int _enemyCount = 0;  // Current number of spawned enemies
    public RuntimeAnimatorController animatorController; // Animator to set to all prefabs
    

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
            
            
            Animator animator = enemy.GetComponent<Animator>();
            animator.runtimeAnimatorController = animatorController;
        
            // Add a NavMeshAgent component to the enemy
            NavMeshAgent agent = enemy.AddComponent<NavMeshAgent>();
            
            
            // Attach an array of scripts to the enemy
            // foreach (System.Type scriptType in scriptsList)
            // {
            //     enemy.AddComponent(scriptType);
            // }
            
            Zombie_Health zombieHealth = enemy.AddComponent<Zombie_Health>();
            
            CapsuleCollider collider = enemy.AddComponent<CapsuleCollider>();
            collider.isTrigger = true;
            collider.center = new Vector3(0, 0.8f, 0);
            collider.radius = 0.3f;
            collider.height = 2f;
            
            Right_Hand rightHand = enemy.AddComponent<Right_Hand>();
        
            
            Zombie zombie = enemy.AddComponent<Zombie>();
            zombie.animator = animator;
            zombie.agent = agent;
            zombie.hand_R = enemy.transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R/Shoulder_R/Elbow_R/Hand_R").gameObject;

            _enemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}