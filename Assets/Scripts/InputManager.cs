using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public event EventHandler OnInteractAction;

    private InputActions actions;

    private void Awake() {
        actions = new InputActions();
        actions.Player.Enable();
        actions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = actions.Player.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }
}
