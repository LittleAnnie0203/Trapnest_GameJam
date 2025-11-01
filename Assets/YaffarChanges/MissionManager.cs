using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
     public enum MissionState
    {
        NotStarted,
        FoundBracelet,
        TalkedToJamel,
        TalkedToBetty,
        Completed
    }

    public MissionState currentState = MissionState.NotStarted;

    public void BraceletFound()
    {
        if (currentState == MissionState.NotStarted)
        {
            currentState = MissionState.FoundBracelet;
            Debug.Log("Has encontrado la manilla. Habla con Jamel.");
        }
    }

    public void TalkedToJamel()
    {
        if (currentState == MissionState.FoundBracelet)
        {
            currentState = MissionState.TalkedToJamel;
            Debug.Log("Ahora ve a hablar con Betty.");
        }
    }

    public void TalkedToBetty()
    {
        if (currentState == MissionState.TalkedToJamel)
        {
            currentState = MissionState.Completed;
            Debug.Log("Misión completada: Jamel y Betty se reconciliaron.");
        }
    }
}
