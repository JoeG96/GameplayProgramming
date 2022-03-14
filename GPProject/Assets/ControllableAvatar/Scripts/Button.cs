using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    private InputManager inputManager;
    public Door door;
    public TextMeshPro useText;
    public bool buttonPressed;

    private float speed = 1f;
    public float pushAmount;
    public Vector3 pushDirection = Vector3.back;
    private Vector3 startPosition;

    private Coroutine animateButtonPress;
    public GameObject buttonCamera;
    public GameObject doorCamera;

    private bool enableButtonCam = false;
    private bool enableDoorCam = false;


    private float time;

    private void Awake()
    {
        GameObject playerObject = GameObject.Find("Player");
        inputManager = playerObject.GetComponent<InputManager>();
        startPosition = transform.position;
        buttonCamera.SetActive(false);
        doorCamera.SetActive(false);
    }

    private void Update()
    {
        if (enableButtonCam)
        {
            Debug.Log("Button Camera Active");
            buttonCamera.SetActive(true);
            doorCamera.SetActive(false);
        }
        else if (enableDoorCam)
        {
            Debug.Log("Door Camera Active");
            buttonCamera.SetActive(false);
            doorCamera.SetActive(true);
        }
        else
        {
            //Debug.Log("Player Camera Active");
            buttonCamera.SetActive(false);
            doorCamera.SetActive(false);
        }

        if (buttonPressed)
        {
            Invoke("EnableButtonCam", 0.1f);
            Invoke("ButtonPress", 0.5f);
            Invoke("DisableButtonCam", 2f);
            Invoke("EnableDoorCam", 0.1f);
            if (door.isOpen)
            {
                Invoke("DoorClose", 2);
            }
            else
            {
                Invoke("DoorOpen", 2);
            }
            buttonPressed = false;
            Invoke("DisableDoorCam", 3);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            useText.gameObject.SetActive(true);

            if (door.isOpen)
            { useText.SetText("Press X to close"); }
            else
            { useText.SetText("Press X to Open"); }

            if (inputManager.x_Input)
            {
                buttonPressed = true;
            }
            else
            { 
                buttonPressed = false;
            }
        }
        else
        { useText.gameObject.SetActive(false); }
    }

    private IEnumerator PushButton()
    {
        Vector3 pushedPosition = startPosition + pushAmount * pushDirection; ;
        Vector3 unPushedPosition = startPosition;

        float time = 0;
        while(time < 1)
        {
            transform.position = Vector3.Lerp(pushedPosition, unPushedPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }

    }

    private void DoorClose()
    {
        door.Close();
    }
    private void DoorOpen()
    {
        door.Open(transform.position);
    }
    private void ButtonPress()
    {
        animateButtonPress = StartCoroutine(PushButton());
    }
    private void EnableDoorCam()
    {
        enableDoorCam = true;
    }
    private void EnableButtonCam()
    {
        enableButtonCam = true;
    }
    private void DisableDoorCam()
    {
        enableDoorCam = false;
    }
    private void DisableButtonCam()
    {
        enableButtonCam = false;
    }
}
