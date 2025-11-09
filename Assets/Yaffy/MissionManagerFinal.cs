using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerFinal : MonoBehaviour
{
    public enum MissionState
    {
        Start,        // Antes de hablar con Yaffy
        TalkedToYaffy,// Moshi habló con Yaffy (misión activa)
        FoundCollar,  // Moshi encontró el collar
        ReturnedCollar,// Moshi entregó el collar a Yaffy
        MissionComplete // Se muestra final
    }

    [Header("Estado actual")]
    public MissionState currentState = MissionState.Start;

    [Header("Referencias de escena")]
    [SerializeField] private GameObject yaffyNPC;      // NPC Yaffy (GameObject)
    [SerializeField] private GameObject collarObject;  // El objeto collar (GameObject)
    [SerializeField] private GameObject finalCanvas;   // FinalCanvas (UI) - desactivado por defecto

    void Start()
    {
        // Inicializamos: collar invisible hasta que hablemos con Yaffy
        SetState(MissionState.Start);
        if (finalCanvas != null) finalCanvas.SetActive(false);
    }

    public void TalkedToYaffy()
    {
        if (currentState == MissionState.Start)
        {
            Debug.Log("[Final] Hablaste con Yaffy: misión activada - busca el collar.");
            SetState(MissionState.TalkedToYaffy);
        }
        else if (currentState == MissionState.ReturnedCollar)
        {
            // ya devolviste el collar → cerrar (por si el jugador habla otra vez)
            CompleteMission();
        }
    }

    public void FoundCollar()
    {
        if (currentState == MissionState.TalkedToYaffy)
        {
            Debug.Log("[Final] Collar encontrado.");
            SetState(MissionState.FoundCollar);
        }
    }

    public void ReturnedCollar()
    {
        if (currentState == MissionState.FoundCollar)
        {
            Debug.Log("[Final] Collar entregado a Yaffy.");
            SetState(MissionState.ReturnedCollar);
        }
    }

    private void CompleteMission()
    {
        if (currentState == MissionState.ReturnedCollar)
        {
            currentState = MissionState.MissionComplete;
            Debug.Log("[Final] Misión final completada. Mostrando corte final.");
            ShowEnding();
        }
    }

    private void SetState(MissionState newState)
    {
        currentState = newState;

        // Activaciones / desactivaciones que suelen olvidarse
        switch (currentState)
        {
            case MissionState.Start:
                if (collarObject != null) collarObject.SetActive(false); // collar oculto hasta empezar
                if (yaffyNPC != null) yaffyNPC.SetActive(true);
                break;

            case MissionState.TalkedToYaffy:
                if (collarObject != null) collarObject.SetActive(true); // aparece el collar
                break;

            case MissionState.FoundCollar:
                // collar recogido por el jugador: collarObject probablemente se desactive en el Pickup
                break;

            case MissionState.ReturnedCollar:
                // puede usarse para cambiar animaciones / diálogo
                break;

            case MissionState.MissionComplete:
                // todo lo visual queda a final canvas
                break;
        }
    }

    private void ShowEnding()
    {
        if (finalCanvas != null)
        {
            finalCanvas.SetActive(true);
            // si deseas pausar el juego mientras se muestra el final:
            Time.timeScale = 0f;
        }
    }
}
