using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    [Header("Slime Objects")]
    public GameObject Slime3x3;
    public GameObject Slime2x2;
    public GameObject Slime1x1;
    private GameObject Enemy3x3;
    private GameObject Enemy2x2x1;
    private GameObject Enemy2x2x2;
    private GameObject Enemy1x1x1;
    private GameObject Enemy1x1x2;
    private GameObject Enemy1x1x3;
    private GameObject Enemy1x1x4;

    public GameObject spawnLocation;

    [Header("Conditions")]
    public bool bigSlimeSpawned = false;
    public bool bigSlimeDestroyed = false;
    public bool middleSlimeSpawned = false;
    public bool middleSlimeDestroyed = false;
    public bool smallSlimeSpawned = false;
    public bool smallSlimeDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        SpawnSlimes();


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnSlimes()
    {
        if (!bigSlimeDestroyed && !bigSlimeSpawned)
        {
            // Spawn Big Slime
            Enemy3x3 = (GameObject)Instantiate(Resources.Load("Cube Enemy 3x3"));
            Enemy3x3.transform.position = spawnLocation.transform.position;
            bigSlimeSpawned = true;
        }
        else if (bigSlimeDestroyed && !middleSlimeDestroyed)
        {
            // Spawn Middle Slimes
            Enemy2x2x1 = (GameObject)Instantiate(Resources.Load("Cube Enemy 2x2"));
            Enemy2x2x2 = (GameObject)Instantiate(Resources.Load("Cube Enemy 2x2"));

            middleSlimeSpawned = true;
        }
        else
        {
            // Spawn Small Slimes
            Enemy1x1x1 = (GameObject)Instantiate(Resources.Load("Cube Enemy 1x1"));
            Enemy1x1x2 = (GameObject)Instantiate(Resources.Load("Cube Enemy 1x1"));
            Enemy1x1x3 = (GameObject)Instantiate(Resources.Load("Cube Enemy 1x1"));
            Enemy1x1x4 = (GameObject)Instantiate(Resources.Load("Cube Enemy 1x1"));
            smallSlimeSpawned = true;
        }

    }
}
