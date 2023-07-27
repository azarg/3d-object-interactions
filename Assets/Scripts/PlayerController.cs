using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float turnSpeed = 15;
    private bool isWalking;

    private void Update() {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y += 1;
        } 
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y -= 1;
        } 
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x += 1;
        } 
        if (Input.GetKey(KeyCode.A)) { 
            inputVector.x -= 1;
        }

        inputVector = inputVector.normalized;
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
