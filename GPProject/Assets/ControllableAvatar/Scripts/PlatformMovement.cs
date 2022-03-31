using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private Rigidbody rigidBody;
    private bool isOnPlatform;
    private Rigidbody platformRigidBody;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Debug.Log("Player velocity = " + rigidBody.velocity);

        if (isOnPlatform)
        {
           
            rigidBody.AddForce(platformRigidBody.velocity,ForceMode.VelocityChange);
            //Debug.Log("Is on platform");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //platformRigidBody = other.gameObject.GetComponent<Rigidbody>();
            //isOnPlatform = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //platformRigidBody = null;
            //isOnPlatform = false;
        }
    }

/*    private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Platform")
            {
                platformRigidBody = collision.gameObject.GetComponent<Rigidbody>();
                isOnPlatform = true;

            }
        }*/
/*    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            platformRigidBody = null;
            isOnPlatform = false;
        }
    }*/

}
