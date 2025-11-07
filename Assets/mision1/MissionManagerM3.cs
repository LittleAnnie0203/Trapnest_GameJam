using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerM3 : MonoBehaviour
{
     public enum MissionState
    {
        None,
        FoundLetter,
        TalkedToClaudia,
        TalkedToJavier,
        Completed
    }

    public MissionState currentState = MissionState.None;

    public void FoundLetter()
    {
        if (currentState == MissionState.None)
        {
            currentState = MissionState.FoundLetter;
            Debug.Log("[M3] Carta encontrada. Lleva la carta a Claudia.");
        }
    }

    public void TalkedToClaudia()
    {
        if (currentState == MissionState.FoundLetter)
        {
            currentState = MissionState.TalkedToClaudia;
            Debug.Log("[M3] Hablaste con Claudia. Ve a hablar con Javier.");
        }
    }

    public void TalkedToJavier()
    {
        if (currentState == MissionState.TalkedToClaudia)
        {
            currentState = MissionState.TalkedToJavier;
            Debug.Log("[M3] Hablaste con Javier. Misión completada.");
            CompleteMission();
        }
    }

    private void CompleteMission()
    {
        currentState = MissionState.Completed;
        // Aquí puedes disparar recompensas, eventos de UI, animaciones, etc.
        Debug.Log("[M3] Misión 3: Javier y Claudia se han reconciliado.");

        
    }
}
