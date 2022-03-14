using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
        {
            if (!Door.isOpen)
            {
                Door.Open(other.transform.position);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
        {
            if (Door.isOpen)
            {
                Door.Close();
            }
        }
    }
}
