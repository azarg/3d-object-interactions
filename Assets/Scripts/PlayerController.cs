using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float turnSpeed = 15;
    [SerializeField] InputManager inputManager;

    private bool isWalking;

    private void Update() {
        Vector2 inputVector = inputManager.GetMovementVectorNormalized();

        var moveVector = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveVector != Vector3.zero) {
            isWalking = true;
            transform.position += moveVector * moveSpeed * Time.deltaTime;
            transform.forward = Vector3.Slerp(transform.forward, moveVector, turnSpeed * Time.deltaTime);
        } else {
            isWalking = false;
        }
    }

    public bool IsWalking() {
        return isWalking;
    }
}
