using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        void Update()
        {
            //Forward Movement - Walking
            // Check if "W" key is pressed
            if (Input.GetKey(KeyCode.W))
            {
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
