using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Camera PlayerCam;
    public Camera DragonCam;

    public GameObject Dragon;

    private float speed;
    [SerializeField]
    private float lookSensitivity = 5f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        //Player Camera is default camera
        PlayerCam.enabled = true;
        //Disable Dragon Camera
        DragonCam.enabled = false;
    }

    private void Update()
    {

        //Does player want to mount Dragon?
        if (Vector3.Distance(this.transform.position, Dragon.transform.position) < 5 && Input.GetKeyDown(KeyCode.E))
        {
            //Move Player to mount position
            this.transform.position = DragonCam.transform.position;
            //Disable Player Camera
            PlayerCam.enabled = false;
            //Enable Dragon Camera
            DragonCam.enabled = true;
            //Disable Player Camera Listener 
            PlayerCam.GetComponent<AudioListener>().enabled = false;
            //Enable Dragon Camera Listener 
            DragonCam.GetComponent<AudioListener>().enabled = true;
            //Enable Dragon Controller Script
            Dragon.GetComponent<DragonController>().enabled = true;
            //Disable Projectile Shooter
            this.GetComponent<ProjectileShooter>().enabled = false;
            //Disable Player Controller Script
            this.enabled = false;
        }
        //Check if player wants to sprint
        speed = Input.GetKey(KeyCode.LeftShift) ? 10f : 5f;

        //Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        //Final movement vector
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        //Apply movement
        motor.Move(velocity);

        //Calculate rotation as a 3D vector (turning around)
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(rotation);

        //Calculate camera as a 3D vector (turning around)
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        //Apply rotation
        motor.RotateCamera(cameraRotation);

    }

}
