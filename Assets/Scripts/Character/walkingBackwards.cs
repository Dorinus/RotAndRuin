using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingBackwards : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Backward Movement - Walking Backward
        //Check if "S" key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            //Play walking backward animation
            animator.SetBool("isWalkingBack", true);
        }
        else
        {
            //Stop playing walking animation
            animator.SetBool("isWalkingBack", false);
        }
    }
}
