using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float degreesPerSecond = 45.0f;
    public float amplitude = 0.3f;
    public float frequency = 1;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        posOffset = transform.position; // Store start position
    }

    // Update is called once per frame
    void Update()
    {
        // Spin the object
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up and down
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
