using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
	public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
	public float timeDelay = 2.0f;
	
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		Destroy(bullet, timeDelay);
    }
    }
}
