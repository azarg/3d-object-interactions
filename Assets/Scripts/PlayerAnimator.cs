using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    
    [SerializeField] PlayerController player;
    private Animator animator;

    private const string IS_WALKING = "IsWalking";

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}