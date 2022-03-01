using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;
    PlayerManager playerManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    [Header ("Inputs")]
    public bool y_Input;        // Y Button (north gamepad)                 // ??
    public bool a_Input;        // A Button (south gamepad)                 // Jump
    public bool b_Input;        // B Button (east gamepad)                  // Dodge
    public bool x_Input;        // X Button (west gamepad)                  // Interact
    public bool rb_Input;       // Right Bumper (Right Shoulder gamepad)    // Light Attack
    public bool rt_Input;       // Right Trigger                            // Heavy Attack
    public bool lb_Input;       // Left Bumper (Left Shoulder gamepad)      // Block
    public bool lt_Input;       // Left Trigger                             // ??
    public bool start_Input;    // Start Button
    public bool dpadD_Input;    // D-pad Down
    public bool dpadU_Input;    // D-pad Up
    public bool dpadL_Input;    // D-pad Left
    public bool dpadR_Input;    // D-pad Right


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerManager = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Y.performed += i => y_Input = true;
            playerControls.PlayerActions.Y.canceled += i => y_Input = false;

            playerControls.PlayerActions.A.performed += i => a_Input = true;

            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;

            playerControls.PlayerActions.X.performed += i => x_Input = true;
            playerControls.PlayerActions.X.canceled += i => x_Input = false;

            playerControls.PlayerActions.RB.performed += i => rb_Input = true;
            playerControls.PlayerActions.RB.canceled += i => rb_Input = false;

            playerControls.PlayerActions.RT.performed += i => rt_Input = true;
            playerControls.PlayerActions.RT.canceled += i => rt_Input = false;

            playerControls.PlayerActions.LB.performed += i => lb_Input = true;
            playerControls.PlayerActions.LB.canceled += i => lb_Input = false;

            playerControls.PlayerActions.LT.performed += i => lt_Input = true;
            playerControls.PlayerActions.LT.canceled += i => lt_Input = false;

            playerControls.PlayerActions.Start.performed += i => start_Input = true;
            playerControls.PlayerActions.Start.canceled += i => start_Input = false;

            playerControls.PlayerActions.DpadDown.performed += i => dpadD_Input = true;
            playerControls.PlayerActions.DpadDown.canceled += i => dpadD_Input = false;

            playerControls.PlayerActions.DpadUp.performed += i => dpadU_Input = true;
            playerControls.PlayerActions.DpadUp.canceled += i => dpadU_Input = false;

            playerControls.PlayerActions.DpadLeft.performed += i => dpadL_Input = true;
            playerControls.PlayerActions.DpadLeft.canceled += i => dpadL_Input = false;

            playerControls.PlayerActions.DpadRight.performed += i => dpadR_Input = true;
            playerControls.PlayerActions.DpadRight.canceled += i => dpadR_Input = false;

        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpingInput();
        HandleInteractionInput();
        HandleDodgeInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleSprintingInput()
    {
        if (lb_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleJumpingInput()
    {
        if (a_Input)
        {
            a_Input = false;
            playerLocomotion.HandleJumping();
        }
    }

    private void HandleInteractionInput()
    {
        if (x_Input)
        {
            playerLocomotion.HandleInteract();
            // X INPUT
            // Interact
        }

        if (dpadU_Input)
        {  /*D-pad Up Input*/ }

        if (dpadD_Input)
        {
            if (playerManager.currentHealth > 1)
            { playerManager.TakeDamage(); }

            if (playerManager.currentStamina > 1)
            { playerManager.UseStamina(); }
        }
    }

    private void HandleDodgeInput()
    {
        if (b_Input)
        {
            playerLocomotion.HandleDodge();
        }
    }

    private void HandleAttackInput()
    {
        if (rt_Input)
        {
            playerLocomotion.HandleAttack();
        }

        if (rb_Input)
        {
            
        }

        if (lb_Input)
        { }

        if (lt_Input)
        { 
            //playerLocomotion.HandleBlock();
        }
    }

}
