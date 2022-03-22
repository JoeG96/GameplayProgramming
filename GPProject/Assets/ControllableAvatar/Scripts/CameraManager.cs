using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform targetTransform;   // Camera follow object
    public Transform cameraPivot;       // Object camera uses to pivot
    public Transform cameraTransform;   // transform of camera
    public LayerMask collisionLayers;   // Layers camera collides with
    private float defaultPosition;      // Default position of camera
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;
    public float cameraCollisionRadius = 2;  // Radius of collision sphere
    public float cameraCollisionOffset = 0.2f;  // Distance camera will be from collison objects
    public float minCollisionOffset = 0.2f;

    public float lookAngle; // Vertical Camera Movement
    public float pivotAngle; // Horizontal Camera Movement
    public float minPivotAngle = -15;
    public float maxPivotAngle = 15;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
        HandleCameraSnapping();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;

    }

    private void HandleCameraCollisions()
    {
        float targetPostion = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast
            (cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPostion), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPostion -= (distance - cameraCollisionOffset);
            print("CAMERA COLLISON SPHERECAST");
        }

        if (Mathf.Abs(targetPostion) < minCollisionOffset)
        {
            targetPostion -= minCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPostion, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;

    }

    private void HandleCameraSnapping()
    {
        if (inputManager.dpadR_Input)
        {
            lookAngle += 90;
        }

        if(inputManager.dpadL_Input)
        {
            lookAngle -= 90;
        }
    }

}
