using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleToggle : MonoBehaviour
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
        //Rifle Animations
        //Character has rifle - Rifle Idle
        //TODO - Temporary Solution until rifle logic is setup, use L to toggle rifle
        if(Input.GetKeyDown(KeyCode.L))
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
    }
}
