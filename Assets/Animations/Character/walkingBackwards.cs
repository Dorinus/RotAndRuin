using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingBackwards : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // Movement speed
    public Animator animator; // Animator component reference
    
    private void Update()
    {
        // Check if "S" key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            // Move character forward
            transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);
    
            // Play "walking" animation
            animator.SetBool("isWalkingBack", true);
        }
        else
        {
            // Stop playing "walking" animation
            animator.SetBool("isWalkingBack", false);
        }
    }
}
