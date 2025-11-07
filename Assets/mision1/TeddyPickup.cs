using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyPickup : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private bool pickedUp = false;

    [SerializeField] private MissionManagerM4 missionManagerM4;
    [SerializeField] private GameObject interactionPrompt; // "Presiona E para recoger"
    [SerializeField] private GameObject visualRoot; // el modelo del osito

    void Start()
    {
        if (interactionPrompt != null) interactionPrompt.SetActive(false);
        if (visualRoot == null) visualRoot = this.gameObject;
    }

    void Update()
    {
        if (isPlayerInRange && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpTeddy();
        }
    }

    private void PickUpTeddy()
    {
        pickedUp = true;
        if (missionManagerM4 != null)
            missionManagerM4.FoundTeddy();
        else
            Debug.LogWarning("TeddyPickup: MissionManagerM4 no asignado.");

        if (visualRoot != null) visualRoot.SetActive(false);
        if (interactionPrompt != null) interactionPrompt.SetActive(false);

        Debug.Log("Osito recogido.");
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
