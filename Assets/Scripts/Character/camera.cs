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
	
    // rotation offset to apply to camera position based on character rotation
    public Vector3 rotationOffset = new Vector3(0,0,0);

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
        bool isAiming = animator.GetBool("rifleAim");
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

/*
        // calculate desired position based on character position and rotation
        Quaternion rotation = Quaternion.Euler(target.rotation.eulerAngles.x + rotationOffset.x,
                                                target.rotation.eulerAngles.y + rotationOffset.y,
                                                target.rotation.eulerAngles.z + rotationOffset.z);

        Vector3 desiredPosition = target.position - rotation * Vector3.forward * distance + new Vector3(0, height, 0)+positionOffset;

        // smoothly move camera to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // make camera look at character
        transform.LookAt(target);

*/
        // calculate desired position and rotation based on camera mode
        Transform desiredTransform = cameraMode == 1 ? aimedTransform : noAimTransform;
        Vector3 desiredPosition = desiredTransform.position + positionOffset;
        Quaternion desiredRotation = Quaternion.Euler(desiredTransform.rotation.eulerAngles + rotationOffset);

        // smoothly move camera to desired position and rotation
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.rotation = smoothedRotation;
    }
}
