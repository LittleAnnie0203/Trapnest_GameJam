using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPickup : MonoBehaviour
{
  private bool isPlayerInRange = false;
    private bool pickedUp = false;

    [SerializeField] private MissionManagerM3 missionManagerM3;
    [SerializeField] private GameObject interactionPrompt; // opcional: "Presiona E para recoger"
    [SerializeField, TextArea(2,4)] private string[] pickupDialogue; // opcional, si quieres mostrar diálogo al recoger
    [SerializeField] private GameObject visualRoot; // el mesh/objeto que representa la carta

    private Dialogue dialogueComponent;

    private void Start()
    {
        if (interactionPrompt != null) interactionPrompt.SetActive(false);
        dialogueComponent = GetComponent<Dialogue>();
        // Si tienes visualRoot, úsalo; si no, usa GetComponent<MeshRenderer>()
        if (visualRoot == null)
        {
            visualRoot = this.gameObject;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpLetter();
        }
    }

    private void PickUpLetter()
    {
        pickedUp = true;

        if (missionManagerM3 != null)
            missionManagerM3.FoundLetter();
        else
            Debug.LogWarning("LetterPickup: missionManagerM3 no asignado.");

        // activar diálogo opcional (si este objeto tiene Dialogue)
        if (dialogueComponent != null)
        {
            dialogueComponent.enabled = true;
        }

        // ocultar visual
        if (visualRoot != null)
            visualRoot.SetActive(false);

        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);

        Debug.Log("Carta recogida.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactionPrompt != null) interactionPrompt.SetActive(true);
            Debug.Log("Presiona E para recoger la carta");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactionPrompt != null) interactionPrompt.SetActive(false);
        }
    }
}
