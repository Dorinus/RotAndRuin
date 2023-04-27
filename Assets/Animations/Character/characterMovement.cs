using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
	public float backwardSpeed = 2f;
	public float speed = 5f;
	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Forward Movement - Walking
		// Check if "W" key is pressed
        if (Input.GetKey(KeyCode.W))
          {
                // Move character forward
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
    
                // Play "walking" animation
                animator.SetBool("isWalking", true);
          }
          else
          {
                // Stop playing "walking" animation
                animator.SetBool("isWalking", false);
          }
		//Backward Movement - Walking Backward
		//Check if "S" key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            //Move character backward
            transform.Translate(Vector3.forward * -1 * backwardSpeed * Time.deltaTime);
    
            //Play walking backward animation
            animator.SetBool("isWalkingBack", true);
        }
        else
        {
            //Stop playing walking animation
            animator.SetBool("isWalkingBack", false);
        }
		//Rifle Animations
		//Character has rifle - Rifle Idle
		//TODO - Temporary Solution until rifle logic is setup, use L to toggle rifle
		if(Input.GetKey(KeyCode.L))
		{
			bool hasRifle = animator.GetBool("hasRifle");
			
			//Set Rifle Idle Animation
			animator.SetBool("hasRifle",!hasRifle);
		}
		/*else
		{
			animator.SetBool("hasRifle",false);
		}
*/
		//Character is aiming - Rifle Aim
		if(Input.GetMouseButton(1))
		{
			//Set Rifle Aim Animation
			animator.SetBool("rifleAim",true);
		}
		else
		{
			animator.SetBool("rifleAim",false);
		}
		
    }
}
