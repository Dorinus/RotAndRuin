using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouseMovement : MonoBehaviour
{
    public float sensitivity = 100f;
    public float speed = 3f;
    public float rotationSpeed = 1f;
	public float verticalClampAngle = 10f;
	private float verticalRotation = 0f;
    public Animator animator;
	private bool dead = false;
	void Start()
    {
		animator = GetComponent<Animator>();
		//Lock mouse in view
	    Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
		//Horizontal mouse movement
	    float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		transform.Rotate(Vector3.up, mouseX * rotationSpeed);
		//Vertical mouse movement
		float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
		verticalRotation += mouseY * rotationSpeed;
    	verticalRotation = Mathf.Clamp(verticalRotation, -verticalClampAngle, verticalClampAngle);
    	transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0);

        float forwardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");
		//Check if character is dead to block transformation
		bool isDeadCharacter = animator.GetBool("isDeadCharacter");
		if(isDeadCharacter)
		{
			//Set is dead to true because the player death state will be true for 1 second only
			dead = true;
		}
		if(!dead)
		{
		//Transform mouse movement if player is not dead
        transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * strafeInput * speed * Time.deltaTime);
		}
    }
}
