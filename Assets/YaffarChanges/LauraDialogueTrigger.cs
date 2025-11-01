using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauraDialogueTrigger : MonoBehaviour
{
    public MissionManager missionManager;
    private Dialogue dialogueScript;

    void Start()
    {
        dialogueScript = GetComponent<Dialogue>();
    }

    void Update()
    {
        // Solo permitir hablar si el jugador ya encontró la manilla
        if (missionManager.currentState == MissionManager.MissionState.FoundBracelet)
        {
            dialogueScript.enabled = true;
        }
        else
        {
            dialogueScript.enabled = false;
        }

        // Si el diálogo terminó, pasar al siguiente estado
        if (!dialogueScript.isActiveAndEnabled && missionManager.currentState == MissionManager.MissionState.FoundBracelet)
        {
            missionManager.TalkedToJamel();
        }
    }
}
