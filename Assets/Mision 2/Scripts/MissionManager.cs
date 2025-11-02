using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
     public enum MissionState
    {
        NotStarted,
        FoundBracelet,
        TalkedToLaura,
        TalkedToBetty,
        Completed
    }

    public MissionState currentState = MissionState.NotStarted;

    public void BraceletFound()
    {
        if (currentState == MissionState.NotStarted)
        {
            currentState = MissionState.FoundBracelet;
            Debug.Log("Has encontrado la manilla. Habla con Laura.");
        }
    }

    public void TalkedToLaura()
    {
        if (currentState == MissionState.FoundBracelet)
        {
            currentState = MissionState.TalkedToLaura;
            Debug.Log("Ahora ve a hablar con Betty.");
        }
    }

    public void TalkedToBetty()
    {
        if (currentState == MissionState.TalkedToLaura)
        {
            currentState = MissionState.Completed;
            Debug.Log("Misión completada: Laura y Betty se reconciliaron.");
        }
    }
}
