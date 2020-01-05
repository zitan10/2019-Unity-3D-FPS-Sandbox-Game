using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    GameObject prefab;
    public Camera cam;
    public GameObject gun;

    // Use this for initialization
    void Start () {
        prefab = Resources.Load("Projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

        //If left mouse button clicked
		if (Input.GetButtonDown("Fire1"))
        {
            //Shoot Projectile

            //Generate Projectile
            GameObject projectile = Instantiate(prefab) as GameObject;
            
            //Position of Projectile should be infront of camera, at the end of the gun barrel
            projectile.transform.position = cam.transform.forward + gun.transform.position;

            //Speed of projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.forward * 100;
        }
	}
}
