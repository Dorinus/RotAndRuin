using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    public float sensitivity = 100f;
    public float speed = 1f;
    public float rotationSpeed = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

        float forwardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * strafeInput * speed * Time.deltaTime);
        
    }
}
