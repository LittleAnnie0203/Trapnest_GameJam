using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerM4 : MonoBehaviour
{
    public enum MissionState
    {
        None,
        FoundChild,
        FoundTeddy,
        ReturnedTeddy,
        Completed
    }

    public MissionState currentState = MissionState.None;

    public void FoundChild()
    {
        if (currentState == MissionState.None)
        {
            currentState = MissionState.FoundChild;
            Debug.Log("[M4] Has encontrado al niño. Necesita su osito.");
        }
    }

    public void FoundTeddy()
    {
        if (currentState == MissionState.FoundChild)
        {
            currentState = MissionState.FoundTeddy;
            Debug.Log("[M4] Recogiste el osito. Llévaselo al niño.");
        }
    }

    public void ReturnedTeddy()
    {
        if (currentState == MissionState.FoundTeddy)
        {
            currentState = MissionState.ReturnedTeddy;
            Debug.Log("[M4] Le devolviste el osito al niño. Informa a la madre.");
        }
    }

    public void CompleteMission()
    {
        if (currentState == MissionState.ReturnedTeddy || currentState == MissionState.FoundTeddy)
        {
            currentState = MissionState.Completed;
            Debug.Log("[M4] Misión 4 completada: Madre y niño reunidos.");
            // Aquí dispara recompensas, UI, sonidos, etc.
        }
    }
}
