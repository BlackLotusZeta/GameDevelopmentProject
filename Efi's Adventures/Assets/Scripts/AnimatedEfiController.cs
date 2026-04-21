using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedEfiController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 15f;
    public float rotationSpeed = 100f;

    private CharacterController characterController;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);


    }
}
