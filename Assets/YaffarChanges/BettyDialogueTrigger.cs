using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettyDialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public MissionManager missionManager;
    private Dialogue dialogueScript;

    void Start()
    {
        dialogueScript = GetComponent<Dialogue>();
    }

    void Update()
    {
        // Solo permitir hablar si ya habló con Jamel
        if (missionManager.currentState == MissionManager.MissionState.TalkedToJamel)
        {
            dialogueScript.enabled = true;
        }
        else
        {
            dialogueScript.enabled = false;
        }

        // Si el diálogo terminó, completar la misión
        if (!dialogueScript.isActiveAndEnabled && missionManager.currentState == MissionManager.MissionState.TalkedToJamel)
        {
            missionManager.TalkedToBetty();
        }
    }
}
