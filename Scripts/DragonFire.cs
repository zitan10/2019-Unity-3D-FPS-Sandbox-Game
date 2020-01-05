using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour {

    Transform DragonFireObject;

	// Use this for initialization
	void Start () {
        DragonFireObject = this.transform.Find("DragonFire");
        DragonFireObject.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")){
            DragonFireObject.gameObject.SetActive(true);
        }
        else
        {
            DragonFireObject.gameObject.SetActive(false);
        }
	}
}
