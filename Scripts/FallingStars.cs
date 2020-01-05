using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStars : MonoBehaviour {

    GameObject prefab;

    // Use this for initialization
    void Start () {
        prefab = Resources.Load("FallingStar") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject fallingStar = Instantiate(prefab) as GameObject;
        fallingStar.transform.position = new Vector3(Random.Range(-640/2, 640/2), 250, Random.Range(-640 / 2, 640 / 2));
    }
}
