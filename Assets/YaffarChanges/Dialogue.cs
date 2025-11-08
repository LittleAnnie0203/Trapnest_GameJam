using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Header("Manejadores de misión (elige cuál usar)")]
    [SerializeField] private MissionManager missionManager;      // Misión de las niñas
    [SerializeField] private MissionManagerM3 missionManagerM3;  // Misión de la pareja
    [SerializeField] private MissionManagerM4 missionManagerM4;  // Misión del osito

    [Header("Configuración del diálogo")]
    [SerializeField] private string npcName;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField, TextArea(4, 6)] private string[] secondaryDialogueLines;

    private bool didDialogueStart = false;
    private int lineIndex = 0;
    private float typingTime = 0.05f;
    private bool isPlayerInRange;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        if (npcName == "Niño" && missionManagerM4 != null)
        {
            if (missionManagerM4.currentState == MissionManagerM4.MissionState.FoundBear)
            dialogueLines = secondaryDialogueLines; // usa el segundo diálogo (tras encontrar el osito)
        }
        if (npcName == "Madre" && missionManagerM4 != null)
        {
            if (missionManagerM4.currentState == MissionManagerM4.MissionState.Completed)
            dialogueLines = secondaryDialogueLines; // usa el segundo diálogo (tras encontrar el osito)
        }
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            // Cierra el diálogo
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            Time.timeScale = 1f;

            // ✅ Determina a qué misión pertenece este NPC
            HandleMissionProgress();
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerInRange = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerInRange = false;
    }

    // 👇 Esta parte unifica el progreso de misiones
    private void HandleMissionProgress()
    {
        // -----------------------
    // Misión 1: Las niñas
    // -----------------------
    if (missionManager != null)
    {
        if (npcName == "Laura")
            missionManager.TalkedToLaura();
        else if (npcName == "Betty")
            missionManager.TalkedToBetty();
    }

    // -----------------------
    // Misión 3: La pareja
    // -----------------------
    if (missionManagerM3 != null)
    {
        if (npcName == "Claudia")
            missionManagerM3.TalkedToClaudia();
        else if (npcName == "Javier")
            missionManagerM3.TalkedToJavier();
    }

    // -----------------------
    // Misión 4: Madre e Hijo
    // -----------------------
    if (missionManagerM4 != null)
    {
        if (npcName == "Madre")
        {
            if (missionManagerM4.currentState == MissionManagerM4.MissionState.NotStarted)
                missionManagerM4.TalkedToMother();
            else if (missionManagerM4.currentState == MissionManagerM4.MissionState.Completed)
                missionManagerM4.TalkedToMotherAgain();
        }
        else if (npcName == "Niño")
        {
            missionManagerM4.TalkedToChild();
        }
    }
    }
}
