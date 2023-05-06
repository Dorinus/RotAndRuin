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
	    //Check if character is dead
	    bool isDeadCharacter = animator.GetBool("isDeadCharacter");
	    if(isDeadCharacter)
	    {
		    //Set dead to true because character death state is true for 1 second only
		    dead = true;
	    }
	    //If player is not dead continue
	    if (!dead)
	    {
		    //Check for left mouse click
		    if (Input.GetMouseButtonDown(0))
		    {
			    //Create bullet
			    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			    //Play shooting sound
			    shootingSound.Play();
			    //Destroy bullet after timedelay
			    Destroy(bullet, timeDelay);
		    }
	    }
    }
}
