using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerFinal : MonoBehaviour
{
    public enum MissionState
    {
        Start,          // Antes de hablar con Yaffy
        TalkedToYaffy,  // Moshi habló con Yaffy
        FoundCollar,    // Moshi recogió el collar
        ReturnedCollar, // Moshi se lo entrega a Yaffy
        MissionComplete // Final del juego
    }

    [Header("Estado actual de la misión")]
    public MissionState currentState = MissionState.Start;

    [Header("Referencias")]
    [SerializeField] private GameObject yaffyNPC;
    [SerializeField] private GameObject collarObject;
    [SerializeField] private GameObject finalCanvas; // Imagen + texto final

    void Start()
    {
        SetState(MissionState.Start);
        if (finalCanvas != null) finalCanvas.SetActive(false);
    }

    public void TalkedToYaffy()
    {
        if (currentState == MissionState.Start)
        {
            Debug.Log("Yaffy recuerda a Mochi...");
            SetState(MissionState.TalkedToYaffy);
        }
        else if (currentState == MissionState.ReturnedCollar)
        {
            Debug.Log("Moshi entrega el collar. Final de la historia ❤️");
            SetState(MissionState.MissionComplete);
            ShowEnding();
        }
    }

    public void FoundCollar()
    {
        if (currentState == MissionState.TalkedToYaffy)
        {
            Debug.Log("Moshi encontró el collar de Mochi 🐾");
            SetState(MissionState.FoundCollar);
        }
    }

    public void ReturnedCollar()
    {
        if (currentState == MissionState.FoundCollar)
        {
            Debug.Log("Yaffy recibe el collar. Su corazón sana poco a poco 💖");
            SetState(MissionState.ReturnedCollar);
        }
    }

    private void SetState(MissionState newState)
    {
        currentState = newState;

        if (collarObject != null)
        {
            // El collar solo aparece después de hablar con Yaffy
            collarObject.SetActive(currentState == MissionState.TalkedToYaffy);
        }
    }

    private void ShowEnding()
    {
        if (finalCanvas != null)
        {
            finalCanvas.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego para mostrar el final
        }
    }
}
