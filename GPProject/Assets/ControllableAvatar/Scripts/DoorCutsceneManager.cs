using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class DoorCutsceneManager : MonoBehaviour
{

    private InputManager inputManager;

    [Header("Objects")]
    public Door door;
    public GameObject button;
    public GameObject doorCamera;
    public PlayableDirector playableDirector;

    [Header("Stuff")]
    public TextMeshPro useText;
    private float speed = 1f;
    public float pushAmount;
    public Vector3 pushDirection = Vector3.back;
    private Vector3 startPosition;

    private bool enableDoorCam;
    public bool buttonPressed;
    private Coroutine animateButtonPress;

    private void Awake()
    {
        GameObject playerObject = GameObject.Find("Player");
        inputManager = playerObject.GetComponent<InputManager>();

/*        GameObject timeline = GameObject.Find("Timeline");
        playableDirector = timeline.GetComponent<PlayableDirector>();*/

        doorCamera.SetActive(false);
        startPosition = transform.position;

        playableDirector.played += DirectorPlayed;
        playableDirector.stopped += DirectorStopped;
       
        
    }

    private void Update()
    {
        if (buttonPressed)
        {
            Invoke("ButtonPress", 0.1f);
            doorCamera.SetActive(true);
            StartTimeline();
            if (door.isOpen)
            {
                Invoke("DoorClose", 2);
            }
            else
            {
                Invoke("DoorOpen", 2);
            }
            buttonPressed = false;
            doorCamera.SetActive(false);
        }

        /*if (enableDoorCam)
        {
            doorCamera.SetActive(true);
        }
        else 
        {
            doorCamera.SetActive(false);
        }*/
        
        // When overlapping 
        //  If x_input is triggered
        //      Set button camera to active
        //      Play animation of player clicking button
        //      Wait time for animation to be done 
        //      Set door camera to active
        //      Play animation of door opening
        //      Set door camera to false
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            useText.gameObject.SetActive(true);
            if (door.isOpen)
            {
                useText.SetText("Press X to close");
            }
            else
            { 
                useText.SetText("Press X to Open");
            }


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
        {
            useText.gameObject.SetActive(false);
        }
    }

    private IEnumerator PushButton()
    {
        Vector3 pushedPosition = startPosition + pushAmount * pushDirection; ;
        Vector3 unPushedPosition = startPosition;

        float time = 0;
        while (time < 1)
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
    
    private void DirectorPlayed(PlayableDirector obj)
    {

    }

    private void DirectorStopped(PlayableDirector obj)
    {

    }

    public void StartTimeline()
    {
        Debug.Log("Timeline Started");
        doorCamera.SetActive(true);
        playableDirector.Play();
    }

}
