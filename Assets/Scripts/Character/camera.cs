using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 1.0f;
    public float smoothSpeed = 10.0f;
    public Animator animator;
	
    //rotation offset
    public Vector3 rotationOffset = new Vector3(0,0,0);
	//position offset - unused but functional
    public Vector3 positionOffset = new Vector3(0,0,0);

    public Transform aimedTransform;
    public Transform noAimTransform;
    private int cameraMode = 0;

    void Start()
    {
        GameObject character = GameObject.Find("Character_MilitaryFemale_01");
        animator = character.GetComponent<Animator>();
    }
    void LateUpdate() {
		//Boolean to check if user is aiming
        bool isAiming = animator.GetBool("rifleAim");
		//Activate aiming mode depending on if user is aiming or not
        if (isAiming)
        {
            //Aiming mode
            cameraMode = 1;
        }
        else
        {
            //Normal Mode
            cameraMode = 0;
        }

        // calculate desired position and rotation based on camera mode
        Transform desiredTransform = cameraMode == 1 ? aimedTransform : noAimTransform;
        Vector3 desiredPosition = desiredTransform.position + positionOffset;
        Quaternion desiredRotation = Quaternion.Euler(desiredTransform.rotation.eulerAngles + rotationOffset);

        //smoothled position and rotation
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
		//Transform positon and rotation
        transform.position = smoothedPosition;
        transform.rotation = smoothedRotation;
    }
}
