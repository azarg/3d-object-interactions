using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    
    [SerializeField] PlayerController player;
    [SerializeField] Animator animator;

    private const string IS_WALKING = "IsWalking";

    private void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}