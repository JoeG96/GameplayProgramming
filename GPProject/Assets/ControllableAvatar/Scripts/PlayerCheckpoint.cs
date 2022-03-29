using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{

    //[SerializeField] GameObject checkpoint;
    [SerializeField] GameObject player;
    private Vector3 spawnPoint;
    private bool respawn = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -20f)
        {
            player.transform.position = spawnPoint;
        }
        if (respawn)
        {
            player.transform.position = spawnPoint;
            respawn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            spawnPoint = other.gameObject.transform.position;
            Debug.Log("Checkpoint Triggered");
            //Debug.Log("Spawn Point: " + spawnPoint);
            //Debug.Log("Game Object: " + gameObject.transform.position);

        }

        if (other.gameObject.CompareTag("Respawn Object"))
        {
            //spawnPoint = gameObject.transform.position;
            Debug.Log("Respawn Triggered");
            //Debug.Log("Spawn Point: " + spawnPoint);
            //Debug.Log("Game Object: " + gameObject.transform.position);
            respawn = true;
        }
        
        
    }
}
