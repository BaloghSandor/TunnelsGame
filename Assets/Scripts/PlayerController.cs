using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 17.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float maxStamina = 100f;
    public float minStamina = 0f;
    public float currentStamina;
    private bool stamina_recovery = false;
    public Stamina_Bar_Script stamina_bar;
    Ray RayOrigin;
    RaycastHit HitInfo;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        stamina_bar.SetMaxStamina(maxStamina);
        stamina_bar.SetMinStamina(minStamina);

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Stamina:

        stamina_bar.SetStamina(currentStamina);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MinusStamina(15f);
            stamina_recovery = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstaMinusStamina(15f);
            stamina_recovery = false;
        }

        void MinusStamina(float stam_loss)
        {
            currentStamina -= stam_loss * Time.deltaTime;
            stamina_bar.SetStamina(currentStamina);
        }
        
        void InstaMinusStamina(float insta_stam_loss)
        {
            currentStamina -= insta_stam_loss;
            stamina_bar.SetStamina(currentStamina);
        }

        if (currentStamina <= 0f)
        {
            runningSpeed = walkingSpeed;
            jumpSpeed = 0f;
            currentStamina = 0f;
        }
        else
        {
            runningSpeed = 17.5f;
            jumpSpeed = 8f;
        }

        // Stamina Recovery

        if (currentStamina < 100f)
        {
            stamina_recovery = true;   
        }

        if (stamina_recovery)
        {
            StaminaRecover(5f);
        }

        if (currentStamina >= 100f)
        {
            stamina_recovery = false;
            currentStamina = 100f;
        }

        void StaminaRecover(float stam_recovery_value)
        {
            currentStamina += stam_recovery_value * Time.deltaTime;
            stamina_bar.SetStamina(currentStamina);
        }
    }
}