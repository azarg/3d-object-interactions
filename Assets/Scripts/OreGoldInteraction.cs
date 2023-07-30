
using UnityEngine;

public class OreGoldInteraction : MonoBehaviour, IInteractable {

    public void DisplayInteractionUI() {
        Debug.Log("press E to mine gold");
    }

    public void Interact() {
        Debug.Log("mined gold...");
    }
}