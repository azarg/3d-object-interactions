using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float turnSpeed = 15;
    [SerializeField] InputManager inputManager;

    private bool walkingAnimationEnabled;
    private readonly float interactionDistance = 1f;
    private CapsuleCollider playerCollider;
    
    private void Awake() {
        playerCollider = GetComponent<CapsuleCollider>();
    }

    private void Update() {
        Vector2 inputVector = inputManager.GetMovementVectorNormalized();
        HandleMovementAnimation(inputVector);
        HandleMovement(inputVector);
        HandleInteraction();
    }

    public bool IsWalking() {
        return walkingAnimationEnabled;
    }

    private void HandleInteraction() {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, interactionDistance)) {
            //Debug.Log(hitInfo);
        };
    }

    private void HandleMovementAnimation(Vector2 inputVector) {
        walkingAnimationEnabled = inputVector != Vector2.zero;
    }

    private void HandleMovement(Vector2 inputVector) {
        // no need for movement handling if there is no input
        if (inputVector == Vector2.zero) return;

        // calculate move vector and turn in that direction
        var moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, turnSpeed * Time.deltaTime);

        // if cannot move in the direction of input vector, try moving horizontally or vertailly
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = CanMove(moveDirection, moveDistance);
        if (!canMove) {
            
            var moveDirectionX = new Vector3(inputVector.x, 0, 0);
            canMove = CanMove(moveDirectionX, moveDistance) ;
            if (canMove) {
                moveDirection = moveDirectionX;
            }
            else {
                var moveDirectionY = new Vector3(0, 0, inputVector.y);
                canMove = CanMove(moveDirectionY, moveDistance);
                if (canMove) {
                    moveDirection = moveDirectionY;
                }
            }
        }

        if (canMove) {
            transform.position += moveDirection * moveDistance;
        }
    }

    private bool CanMove(Vector3 moveDirection, float maxDistance) {
        var bottom = transform.position + playerCollider.center - Vector3.up * playerCollider.height / 2;
        var top = transform.position + playerCollider.center + Vector3.up * playerCollider.height / 2;
        var hit = Physics.CapsuleCast(bottom, top, playerCollider.radius, moveDirection, maxDistance);
        return !hit;
    }
}
