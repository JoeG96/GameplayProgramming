using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    InputManager inputManager;
    AnimatorManager animatorManager;

    Vector3 moveDirection;
    Transform cameraObject;
    public Rigidbody rigidBody;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffset = 0.2f;
    public LayerMask groundLayer;

    [Header("Movement Flags")]
    public bool isSprinting;
    public bool isGrounded;
    public bool isJumping;

    [Header("Movement Speeds")]
    public float walkingSpeed = 2f;
    public float runningSpeed = 5;
    public float sprintingSpeed = 8;
    public float rotateSpeed = 5;

    [Header("Jumping")]
    public float jumpHeight = 3;
    public float gravityIntensity = -10;
    public float doubleJumpTimer = 0;
    public bool doubleJumpEnable = false;
    private bool firstJump = false;

    [Header("Boosts")]
    public float boostTimer = 0;
    public bool isSpeedBoosted = false;
    

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        animatorManager = GetComponent<AnimatorManager>();
        rigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        if (playerManager.isInteracting)
        {
            return;
        }
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (isJumping)
            return;

        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (isSpeedBoosted)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                runningSpeed = 5;
                sprintingSpeed = 8;
                boostTimer = 0;
                isSpeedBoosted = false;
            }
        }

        if (doubleJumpEnable)
        {
            doubleJumpTimer += Time.deltaTime;
            if (doubleJumpTimer >= 5)
            {
                doubleJumpTimer = 0;
                doubleJumpEnable = false;
            }
        }

        if (isSprinting)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection * runningSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkingSpeed;
            }
        }

        Vector3 movementVelocity = moveDirection;
        rigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        if (isJumping)
            return;

        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;
        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        Vector3 targetPosition;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;
        targetPosition = transform.position;

        if (!isGrounded && !isJumping)
        {
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("2Hand-Sword-Fall", true);
            }

            animatorManager.animator.SetBool("isUsingRootMotion", false);
            inAirTimer = inAirTimer + Time.deltaTime;
            rigidBody.AddForce(transform.forward * leapingVelocity);
            rigidBody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if (!isGrounded && playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("2Hand-Sword-Land", true);
            }

            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && !isJumping)
        {
            if (playerManager.isInteracting || inputManager.moveAmount > 0)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
            }
            else
            {
                transform.position = targetPosition;
            }
        }

    }

    public void HandleJumping()
    {
        if (isGrounded)
        {
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAnimation("2Hand-Sword-Jump", false);
            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = moveDirection;
            playerVelocity.y = jumpingVelocity;
            rigidBody.velocity = playerVelocity;
            firstJump = true;
        }
        else if (doubleJumpEnable)
        {
            if (firstJump)
            {
                animatorManager.animator.SetBool("isJumping", true);
                animatorManager.PlayTargetAnimation("2Hand-Sword-Jump", false);
                float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
                Vector3 playerVelocity = moveDirection;
                playerVelocity.y = jumpingVelocity;
                rigidBody.velocity = playerVelocity;
                firstJump = false;
            }
        }
    }

    public void HandleDodge()
    {
        if (playerManager.isInteracting)
            return;

        if (playerManager.stamina < playerManager.dodgeCost)
            return;

        animatorManager.PlayTargetAnimation("2Hand-Sword-DiveRoll-Forward1", true, true);
        playerManager.stamina -= playerManager.dodgeCost;
        Debug.Log("Stamina = " + playerManager.stamina);
        // Put i-frame toggle here

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            isSpeedBoosted = true;
            runningSpeed = runningSpeed += 3;
            sprintingSpeed = sprintingSpeed += 3;
            //Destroy(other.gameObject);
        }

        if (other.tag == "Double Jump")
        {
            doubleJumpEnable = true;
            //Destroy(other.gameObject);
        }

        if (other.tag == "Stamina Pickup")
        {
            playerManager.stamina += 25;
            Debug.Log("Stamina = " + playerManager.stamina);
        }

        if (other.tag == "Health Pickup")
        { }

    }
}
