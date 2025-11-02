using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraceletPickup : MonoBehaviour
{
   public MissionManager missionManager;
    private bool isPlayerInRange;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Manilla recogida");
            missionManager.BraceletFound();
            Destroy(gameObject); // elimina la manilla del mundo
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Presiona E para recoger la manilla");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
