using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DragonMotor : MonoBehaviour {

    public Camera DragonCamera;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 CameraRotation = Vector3.zero;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    //Gets a movement vector
    public void Move(Vector3 velocity2)
    {
        velocity = velocity2;
    }

    //Run every physics iteration
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Gets a Rotation vector
    public void Rotate(Vector3 rotation2)
    {
        rotation = rotation2;
    }

    //Perform movement based on velocity variable
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (DragonCamera != null)
        {
            DragonCamera.transform.Rotate(-CameraRotation);
        }
    }

    //Gets a Rotation vector for camera
    public void RotateCamera(Vector3 CameraRotation2)
    {
        CameraRotation = CameraRotation2;
    }
}
