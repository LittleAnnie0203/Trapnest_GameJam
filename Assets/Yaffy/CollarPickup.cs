using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollarPickup : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private bool pickedUp = false;

    [SerializeField] private MissionManagerFinal missionManagerFinal;
    [SerializeField] private GameObject interactionPrompt; // UI "Presiona E"
    [SerializeField] private GameObject visualRoot; // modelo del collar (child)

    void Start()
    {
        if (interactionPrompt != null) interactionPrompt.SetActive(false);
        if (visualRoot == null) visualRoot = this.gameObject;
    }

    void Update()
    {
        if (isPlayerInRange && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpCollar();
        }
    }

    private void PickUpCollar()
    {
        pickedUp = true;
        if (missionManagerFinal != null)
            missionManagerFinal.FoundCollar();
        else
            Debug.LogWarning("CollarPickup: MissionManagerFinal no asignado.");

        if (visualRoot != null) visualRoot.SetActive(false);
        if (interactionPrompt != null) interactionPrompt.SetActive(false);

        Debug.Log("[Final] Collar recogido por el jugador.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactionPrompt != null) interactionPrompt.SetActive(true);
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
