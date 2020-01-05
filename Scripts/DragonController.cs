using UnityEngine;

[RequireComponent(typeof(DragonMotor))]

public class DragonController : MonoBehaviour {

    //Camera Objects
    public Camera PlayerCam;
    public Camera DragonCam;

    //Sound Objects
    public AudioSource DragonFlying;

    //Player Object
    public GameObject Player;

    //Dragon Motor Object
    private DragonMotor motor;

    //Dragon move speed
    private float speed;

    //Animation Object
    new Animator animation;

    //Mouse Sensitivity
    [SerializeField]
    private float lookSensitivity = 5f;

    //Dragon up speed
    private float DragonLiftSpeed = 40f;

    // Use this for initialization
    void Start () {
        motor = GetComponent<DragonMotor>();
        animation = GetComponent<Animator>();
        //Disable Dragon Flying Sound
        DragonFlying.enabled = false;
        //Disable Dragon Controller. Wait for Player to mount to enable.
        this.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Switch to flying animation
        animation.SetBool("isIdle", false);
        animation.SetBool("isFlying", true);

        //Enable Flying Sound
        DragonFlying.enabled = true;

        //Player Dismounts Dragon
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = this.transform.position + new Vector3(5f,5f,5f);
            //Enable Player Camera
            PlayerCam.enabled = true;
            //Disable Dragon Camera Listener 
            DragonCam.GetComponent<AudioListener>().enabled = false;
            //Enable Player Camera Listener 
            PlayerCam.GetComponent<AudioListener>().enabled = true;
            //Disable Dragon Camera
            DragonCam.enabled = false;
            //Enable Projectile Shooter
            Player.GetComponent<ProjectileShooter>().enabled = true;
            //Enable Player Controller Script
            Player.GetComponent<PlayerController>().enabled = true;
            //Disable Dragon Controller Script
            this.enabled = false;
            //Re-enable gravity
            this.GetComponent<Rigidbody>().useGravity = true;
        }

        //Check if player wants to sprint
        speed = Input.GetKey(KeyCode.LeftShift) ? 30f : 15f;

        //Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;
        Vector3 movUp;

        //Dragon Fly Up Mode
        if (Input.GetKey(KeyCode.Space)) {
            //Speed of flying
            movUp = transform.up * DragonLiftSpeed;
            //Disable Gravity when flying
            this.GetComponent<Rigidbody>().useGravity = false;
            //Switch to flying animation
        }
        //Dragon Fly Down Mode
        else if (Input.GetKey(KeyCode.X))
        {
            //fly down
            movUp = transform.up * -DragonLiftSpeed;
        }
        //Dragon Idle Fly Mode
        else
        {
            //Stay at height position
            movUp = transform.up * 0;
        }

        //Final movement vector
        Vector3 velocity = (movHorizontal + movVertical + movUp).normalized * speed;

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
