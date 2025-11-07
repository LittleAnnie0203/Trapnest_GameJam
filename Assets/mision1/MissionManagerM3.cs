using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerM3 : MonoBehaviour
{
    public enum MissionState
    {
        NotStarted,
        FoundLetter,
        TalkedToClaudia,
        TalkedToJavier,
        Completed
    }

    public MissionState currentState = MissionState.NotStarted;

    public void FoundLetter()
    {
        if (currentState == MissionState.NotStarted)
        {
            currentState = MissionState.FoundLetter;
            Debug.Log("Carta encontrada. Lleva la carta a Claudia.");
        }
    }

    public void TalkedToClaudia()
    {
        if (currentState == MissionState.FoundLetter)
        {
            currentState = MissionState.TalkedToClaudia;
            Debug.Log("Has hablado con Claudia. Ahora ve con Javier.");
        }
    }

    public void TalkedToJavier()
    {
        if (currentState == MissionState.TalkedToClaudia)
        {
            currentState = MissionState.Completed;
            Debug.Log("Misión completada: Javier y Claudia se han reconciliado.");
        }
    }
}
