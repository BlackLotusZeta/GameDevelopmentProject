using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Camera rotation based on mouse movement
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 5f;

    // the target that the camera will follow
    public Transform target;
    // the distance the camera will stay from the target
    public float distanceFromTarget = 7;

    // changing the Y-axis displacment level of the camera
    public float displacementY = 1.5f;

    // boolean to toggle following on and off
    public bool follow = true;

    // easing variable
    public float easing = 0.1f;

    /*
    Update the cameras position to follow the target
    */
    void Update()
    {
        // if allowed to follow the target
        if (follow)
        {

            Vector3 newPosition = target.position - (Vector3.forward * distanceFromTarget);

            newPosition.y = target.position.y + displacementY;

            transform.position += (newPosition - transform.position) * easing;

            transform.LookAt(target);

            // move within "distanceFromTarget" metres of the target
            // but retain the same camera rotation at all times
            transform.position = target.position -
            (target.forward * distanceFromTarget);
            // match the rotation of the target so we look directly at it
            transform.rotation = target.rotation;
        }
        else // otherwise just look at the target
        {
            // use LookAt(...) to point towards the target
            transform.LookAt(target);
        }

        // moving the camera in dirextion of mouse
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
