using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    public Light flashLight;

    // Use this for initialization
    void Start()
    {
        flashLight.enabled = false;
    }

    // Update is called once per frame
    void Update () {

        //Turn on/off Flash Light
		if (Input.GetKeyDown("f"))
        {
            flashLight.enabled = !flashLight.enabled;
        }
	}
}
