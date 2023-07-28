using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private InputActions actions;

    private void Awake() {
        actions = new InputActions();
        actions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = actions.Player.Move.ReadValue<Vector2>();
        return inputVector.normalized;
    }
}
