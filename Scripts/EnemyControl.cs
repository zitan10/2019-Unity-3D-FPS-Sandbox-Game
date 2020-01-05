using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public Transform player;
    new Animator animation;
    public bool hit;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animator>();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            animation.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {

        if (animation.enabled != false)
        {
            //Is enemy position close to player position?
            if (Vector3.Distance(player.position, this.transform.position) < 10)
            {
                //Direction from player to enemy
                Vector3 direction = player.position - this.transform.position;
                //Prevent enemy from rotation upwards
                direction.y = 0;
                //Rotate towards player
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f * Time.deltaTime);

                animation.SetBool("isIdle", false);

                //Move enemy towards player if position is close to player
                if (direction.magnitude > 5)
                {
                    this.transform.Translate(0, 0, 0.05f);
                    animation.SetBool("isWalking", true);
                }
                //Attack 
                else
                {
                    animation.SetBool("isAttacking", true);
                    animation.SetBool("isWalking", false);
                }
            }
            //Idle
            else
            {
                animation.SetBool("isIdle", true);
                animation.SetBool("isWalking", false);
                animation.SetBool("isAttacking", false);
            }
        }
	}
}
