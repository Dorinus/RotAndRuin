using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftRightMovementAnimation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        // Check if "A" key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            // Set Left Movement to true
            animator.SetBool("leftMovement", true);
        }
        else
        {
            // Set Left Movement to false
            animator.SetBool("leftMovement", false);
        }
        // Check if "D" key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            // Set Right Movement to true
            animator.SetBool("rightMovement", true);
        }
        else
        {
            // Set Right Movement to false
            animator.SetBool("rightMovement", false);
        }
    }
}
