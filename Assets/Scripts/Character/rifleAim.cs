using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleAim : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
