using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
	public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
	public float timeDelay = 2.0f;
	public AudioSource shootingSound;
	public Animator animator;
	private bool dead = false;
    void Start()
    {
	    animator = GetComponent<Animator>();
    }

    void Update()
    {
	    bool isDeadCharacter = animator.GetBool("isDeadCharacter");
	    if(isDeadCharacter)
	    {
		    dead = true;
	    }
	    if (!dead)
	    {
		    if (Input.GetMouseButtonDown(0))
		    {
			    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			    shootingSound.Play();
			    Destroy(bullet, timeDelay);
		    }
	    }
    }
}
