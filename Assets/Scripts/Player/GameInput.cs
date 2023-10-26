using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnMixAction;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Mix.performed += Mix_performed;

    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // null check OnInteractAction
        OnInteractAction?.Invoke(this, EventArgs.Empty);

    }
    private void Mix_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // null check OnInteractAction
        OnMixAction?.Invoke(this, EventArgs.Empty);

    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            
        return inputVector;
    }
}