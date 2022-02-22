using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public PlayerInputActions playerControls;

    private InputAction move;
    private InputAction attack;
    private InputAction jump;
    private InputAction block;
    private InputAction interact;

    public float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        attack = playerControls.Player.Attack;
        attack.Enable();
        attack.performed += Attack;

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;

        block = playerControls.Player.Block;
        block.Enable();
        block.performed += Block;

        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
        jump.Disable();
        block.Disable();
        interact.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attacked");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumped");
    }

    private void Block(InputAction.CallbackContext context)
    {
        Debug.Log("Blocking");
    }    
    
    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
}
