using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform doorObject;
    public Transform buttonObject;
    public bool buttonPressed;
    public bool isOpen;
    public bool isRotatingDoor;
    public float speed = 1f;

    [Header("Rotation Config")]
    public float rotationAmount;
    public float forwardDirection;

    [Header("Sliding Config")]
    public Vector3 slideDirection = Vector3.back;
    public float slideAmount;

    private Vector3 startRotation;
    private Vector3 startPosition;
    private Vector3 forward;

    private Coroutine animationCoroutine;

    private void Awake()
    {
        startRotation = transform.rotation.eulerAngles;
        startPosition = transform.position;
        forward = transform.right;
    }

    public void Open(Vector3 userPosition)
    {
        if (!isOpen)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            if (isRotatingDoor)
            {
                float dot = Vector3.Dot(forward, (userPosition - transform.position).normalized);
                animationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
            else
            {
                animationCoroutine = StartCoroutine(DoSlidingOpen());
            }
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }

            if (isRotatingDoor)
            {
                animationCoroutine = StartCoroutine(DoRotationClose());
            }
            else
            {
                animationCoroutine = StartCoroutine(DoSlidingClose());
            }

        }
    }

    private IEnumerator DoRotationOpen(float forwardAmount)
    {
        Quaternion StartRotation = transform.rotation;
        Quaternion endRotation;

        if (forwardAmount >= forwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y - rotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y + rotationAmount, 0));
        }

        isOpen = true;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(StartRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion StartRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startRotation);

        isOpen = false;
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(StartRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = startPosition + slideAmount * slideDirection;
        Vector3 StartPosition = transform.position;

        float time = 0;
        isOpen = true;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = startPosition;
        Vector3 StartPosition = transform.position;

        float time = 0;
        isOpen = false;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

}
