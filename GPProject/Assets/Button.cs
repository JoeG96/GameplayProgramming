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

    private void Awake()
    {
        GameObject playerObject = GameObject.Find("Player");
        inputManager = playerObject.GetComponent<InputManager>();
        startPosition = transform.position;
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
                //Debug.Log("Button Pressed");
                buttonPressed = true;
                if (animateButtonPress != null)
                {
                    animateButtonPress = StartCoroutine(PushButton());
                    if (door.isOpen)
                    {
                        door.Close();
                    }
                    else
                    {
                        door.Open(transform.position);
                    }
                }
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

        //Debug.Log("unPushed position =" + unPushedPosition);
        //Debug.Log("Pushed position =" + pushedPosition);

        float time = 0;
        while(time < 1)
        {
            transform.position = Vector3.Lerp(pushedPosition, unPushedPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }

    }
}
