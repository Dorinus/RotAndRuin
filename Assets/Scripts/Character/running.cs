using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class running : MonoBehaviour
{
    public Animator animator;
    private mouseMovement _mouseMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        //Get mouseMovement Script
        _mouseMovement = GetComponent<mouseMovement>();
    }
    void Update()
    {
        //Check if player is aiming
        bool rifleAim = animator.GetBool("rifleAim");
        //Running Movement - Running
        // Check if "Shift" + "W" keys are pressed - with condition that player is not aiming
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !rifleAim)
        {
            // Play "running" animation
            animator.SetBool("isRunning", true);
            //Edit Player Speed
            _mouseMovement.speed = 5f;
        }
        else
        {
            // Stop playing "running" animation
            animator.SetBool("isRunning", false);
            //Put player speed back to normal
            _mouseMovement.speed = 3f;
        }
    }
}
