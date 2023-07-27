using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.PlayerActionActions playerActions;

    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.PlayerAction;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        playerActions.Jump.performed += ctx => motor.Jump();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    void Update()
    {
        if (playerActions.OpenMenu.triggered)
        {
            look.ToggleCursorLock();
        }
    }

    void FixedUpdate()
    {
        motor.ProcessMovement(playerActions.CardinalMovement.ReadValue<Vector2>());
    }

    private void LateUpdate() 
    {
        look.ProcessLook(playerActions.Look.ReadValue<Vector2>());
    }
}
