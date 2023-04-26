using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // Movement speed
        public Animator animator; // Animator component reference
    
        private void Update()
        {
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
        }
}
