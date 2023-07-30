using UnityEngine;

public class OreCopperInteraction : MonoBehaviour, IInteractable {

    public void DisplayInteractionUI() {
        Debug.Log("press E to mine copper");
    }

    public void Interact() {
        Debug.Log("mined copper...");
    }
}