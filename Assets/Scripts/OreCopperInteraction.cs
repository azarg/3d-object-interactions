using TMPro;
using UnityEngine;

public class OreCopperInteraction : MonoBehaviour, IInteractable {
    
    [SerializeField] readonly string interactionText = "Press E to mine copper";
    [SerializeField] TextMeshProUGUI interactionUI;

    public void DisplayInteractionUI() {
        interactionUI.text = interactionText;
        interactionUI.gameObject.SetActive(true);
    }

    public void HideInteractionUI() {
        interactionUI.text = "";
        interactionUI.gameObject.SetActive(false);
    }

    public void Interact() {
        Debug.Log("mined copper...");
    }
}