using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // Reference to the character's transform
    public float distance = 10.0f; // Distance between camera and character
    public float height = 5.0f; // Height of the camera above the character
    public float damping = 2.0f; // Damping factor for camera movement

    private void LateUpdate()
    {
        // Calculate the camera's new position
        Vector3 targetPosition = target.position - target.forward * distance + target.up * height;

        // Move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // Make the camera look at the target
        transform.LookAt(target);
    }

}
