using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerM4 : MonoBehaviour
{
    public enum MissionState { NotStarted, SearchChild, FoundChild, FoundBear, Completed }
    public MissionState currentState = MissionState.NotStarted;

    // Llamado cuando el jugador habla con la madre
    public void TalkedToMother()
    {
        if (currentState == MissionState.NotStarted)
        {
            currentState = MissionState.SearchChild;
            Debug.Log("Misión iniciada: busca al niño.");
        }
    }

    // Llamado cuando el jugador encuentra al niño
    public void TalkedToChild()
    {
        if (currentState == MissionState.SearchChild)
        {
            currentState = MissionState.FoundChild;
            Debug.Log("Has encontrado al niño. Encuentra su osito.");
        }
        else if (currentState == MissionState.FoundBear)
        {
            currentState = MissionState.Completed;
            Debug.Log("El niño tiene su osito. Regresa con la madre.");
        }
    }

    // Llamado cuando el jugador recoge el osito
    public void FoundTeddy()
    {
        if (currentState == MissionState.FoundChild)
        {
            currentState = MissionState.FoundBear;
            Debug.Log("Has encontrado el osito. Llévaselo al niño.");
        }
    }

    // Llamado al final de la misión
    public void TalkedToMotherAgain()
    {
        if (currentState == MissionState.Completed)
        {
            Debug.Log("La misión de la madre y el hijo ha terminado.");
        }
    }
}
