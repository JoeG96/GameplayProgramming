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

        if (respawn)
        {
            /*player.transform.position = spawnPoint;
            respawn = false;*/
            Respawn();
        }
        else if(gameObject.transform.position.y < -20f)
        {
            Respawn();
        }
        /*if (gameObject.transform.position.y < -20f)
        {
            *//*player.transform.position = spawnPoint;*//*
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            spawnPoint = other.gameObject.transform.position;
            Debug.Log("Checkpoint Triggered");
        }

        if (other.gameObject.CompareTag("Respawn Object"))
        {
            //spawnPoint = gameObject.transform.position;
            Debug.Log("Respawn Triggered");
            respawn = true;
        }
        
        
    }

    public void Respawn()
    {
        player.transform.position = spawnPoint;
        respawn = false;
    }
}
