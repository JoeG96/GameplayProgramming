using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    CameraManager cameraManager;
    Animator animator;

    public bool isInteracting;
    public bool isUsingRootMotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
        isInteracting = animator.GetBool("isInteracting");
        isUsingRootMotion = animator.GetBool("isUsingRootMotion");
        playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerLocomotion.isGrounded);
    }
}
