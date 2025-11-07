using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDialogueTrigger : MonoBehaviour
{
   public MissionManagerM4 missionManagerM4;
    private Dialogue dlg;

    [SerializeField] private string npcName = "Nino"; // nombre que pongas en Dialogue

    void Start()
    {
        dlg = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (dlg == null || missionManagerM4 == null) return;

        // Niño: se puede hablar siempre (lo encontramos), pero el diálogo puede cambiar según estado.
        dlg.enabled = true;
    }
}
