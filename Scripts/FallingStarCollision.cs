using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy "Falling Star" Object on collision
public class FallingStarCollision : MonoBehaviour {

    public Transform gameobject;

    private void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}
