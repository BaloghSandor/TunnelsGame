using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 17.5f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public float maxStamina = 100f;
    public float minStamina = 0f;
    public float currentStamina;
    private bool stamina_recovery = false;
    public Stamina_Bar_Script stamina_bar;
    
    public float maxHealth = 100f;
    public float minHealth = 0f;
    public float currentHealth;

    private bool health_recovery = true;
    public Health_Bar_Script health_bar;

    public Generator_script generator;

    public Timer_script timer;

    public First_Demo_Level_Doors_script demo_level;

    public GameObject monster;

    private bool monster_interaction = false;

    public Monster_kill_collision_script second_level_kill_condition;

    public Finishing_room_collision_script game;

    [HideInInspector]
    public bool canMove = true;

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == monster)
        {
            monster_interaction = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == monster)
        {
            monster_interaction = false;
        }
    }  

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        currentStamina = maxStamina;
        stamina_bar.SetMaxStamina(maxStamina);
        stamina_bar.SetMinStamina(minStamina);

        currentHealth = maxHealth;
        health_bar.SetMaxHealth(maxHealth);
        health_bar.SetMinHealth(minHealth);

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

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            MinusStamina(15f);
            stamina_recovery = false;
        }

        void MinusStamina(float stam_loss)
        {
            currentStamina -= stam_loss * Time.deltaTime;
        }

        if (currentStamina <= 0f)
        {
            runningSpeed = walkingSpeed;
            currentStamina = 0f;
        }
        else
        {
            runningSpeed = 17.5f;
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
        }

        // Health:

        health_bar.SetHealth(currentHealth);

        if(demo_level.Demo_level_one)
        {
            if (generator.gen_failure)
            {
                Damage(12f);
            }
        }

        if (!generator.gen_failure && currentHealth < 100f && health_recovery)
        {
            HealthRecovery(5f);
        }

        if (!timer.TimerOn && demo_level.Demo_level_one)
        {
            InstaDeath();
        }

        if (currentHealth <= 0f)
        {
            health_recovery = false;
            currentHealth = 0f;
        }

        if(currentHealth == 0f)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MoveToScene(2);
        }

        if(monster_interaction || second_level_kill_condition.game_over)
        {
            InstaDeath();
        }

        //Win

        if(game.game_finished)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MoveToScene(3);
        }

        //functions

        void InstaDeath()
        {
            currentHealth = 0f;
        }

        void Damage(float health_amount_deduction)
        {
            currentHealth -= health_amount_deduction * Time.deltaTime;
        }

        void HealthRecovery(float recovery_points)
        {
            currentHealth += recovery_points * Time.deltaTime;
        }

        void MoveToScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}