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

    [Header("Current Player Stats")]
    public int currentHealth = 20;
    public int currentStamina = 20;
    public int money = 0;

    [Header ("Player Stats")]
    public int maxHealth = 100;
    public int maxStamina = 100;
    public float healthPerSecond = 2f;
    private float regenHealth;
    public float staminaPerSecond = 5f;
    private float regenStamina;
    public int dodgeCost = 25;

    public HealthBar healthBar;
    public StaminaBar staminaBar;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        healthBar.SetHealth(currentHealth);
        staminaBar.SetStamina(currentStamina);
        
        if (currentHealth < maxHealth)
        {
            regenHealth += Time.deltaTime * healthPerSecond;
            if (regenHealth >= 1)
            {
                int floor = Mathf.FloorToInt(regenHealth);
                currentHealth += floor;
                regenHealth -= floor;
            }
        }
        
        if (currentStamina < maxStamina)
        {
            regenStamina += Time.deltaTime * staminaPerSecond;
            if (regenStamina >= 1)
            {
                int floor = Mathf.FloorToInt(regenStamina);
                currentStamina += floor;
                regenStamina -= floor;
            }
        }
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        //cameraManager.HandleAllCameraMovement();
        isInteracting = animator.GetBool("isInteracting");
        isUsingRootMotion = animator.GetBool("isUsingRootMotion");
        playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerLocomotion.isGrounded);
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }

    public void UseStamina()
    {
        currentStamina -= 1;
    }
}
