using UnityEngine;
using TMPro;

public class MissionUIManager : MonoBehaviour
{
    [Header("Referencias a los MissionManagers")]
    public MissionManager mission1;
    public MissionManagerM3 mission3;
    public MissionManagerM4 mission4;
    public MissionManagerFinal missionFinal; // ← tu misión final de Yaffi

    [Header("Contenedores de UI por misión")]
    public GameObject panelMission1;
    public GameObject panelMission3;
    public GameObject panelMission4;
    public GameObject panelMissionFinal;

    [Header("Textos de Misión 1 (Manilla)")]
    public TextMeshProUGUI step1_M1;
    public TextMeshProUGUI step2_M1;
    public TextMeshProUGUI step3_M1;

    [Header("Textos de Misión 3 (Carta)")]
    public TextMeshProUGUI step1_M3;
    public TextMeshProUGUI step2_M3;
    public TextMeshProUGUI step3_M3;

    [Header("Textos de Misión 4 (Madre/niño/osito)")]
    public TextMeshProUGUI step1_M4;
    public TextMeshProUGUI step2_M4;
    public TextMeshProUGUI step3_M4;
    public TextMeshProUGUI step4_M4;

    [Header("Textos de Misión Final (Yaffi)")]
    public TextMeshProUGUI step1_Final;
    public TextMeshProUGUI step2_Final;
    public TextMeshProUGUI step3_Final;

    void Start()
    {
        // Solo la primera misión activa al inicio
        SetActivePanels(true, false, false, false);
    }

    void Update()
    {
        UpdateMission1UI();
        UpdateMission3UI();
        UpdateMission4UI();
        UpdateMissionFinalUI();

        UpdatePanelVisibility();
    }

    // =====================================================
    // CONTROL DE PANELES
    // =====================================================
    void UpdatePanelVisibility()
    {
        // Mostrar solo la misión activa (o en progreso)
        if (mission1 != null && mission1.currentState != MissionManager.MissionState.Completed)
            SetActivePanels(true, false, false, false);
        else if (mission3 != null && mission3.currentState != MissionManagerM3.MissionState.Completed)
            SetActivePanels(false, true, false, false);
        else if (mission4 != null && mission4.currentState != MissionManagerM4.MissionState.Completed)
            SetActivePanels(false, false, true, false);
        else if (missionFinal != null)
            SetActivePanels(false, false, false, true);
    }

    void SetActivePanels(bool m1, bool m3, bool m4, bool mF)
    {
        if (panelMission1 != null) panelMission1.SetActive(m1);
        if (panelMission3 != null) panelMission3.SetActive(m3);
        if (panelMission4 != null) panelMission4.SetActive(m4);
        if (panelMissionFinal != null) panelMissionFinal.SetActive(mF);
    }

    // =====================================================
    // Misión 1
    // =====================================================
    void UpdateMission1UI()
    {
        if (mission1 == null) return;
        ResetColors(step1_M1, step2_M1, step3_M1);

        switch (mission1.currentState)
        {
            case MissionManager.MissionState.FoundBracelet:
                Mark(step1_M1);
                Highlight(step2_M1);
                break;
            case MissionManager.MissionState.TalkedToLaura:
                Mark(step1_M1);
                Mark(step2_M1);
                Highlight(step3_M1);
                break;
            case MissionManager.MissionState.Completed:
                MarkAll(step1_M1, step2_M1, step3_M1);
                break;
        }
    }

    // =====================================================
    // Misión 3
    // =====================================================
    void UpdateMission3UI()
    {
        if (mission3 == null) return;
        ResetColors(step1_M3, step2_M3, step3_M3);

        switch (mission3.currentState)
        {
            case MissionManagerM3.MissionState.FoundLetter:
                Mark(step1_M3);
                Highlight(step2_M3);
                break;
            case MissionManagerM3.MissionState.TalkedToClaudia:
                Mark(step1_M3);
                Mark(step2_M3);
                Highlight(step3_M3);
                break;
            case MissionManagerM3.MissionState.Completed:
                MarkAll(step1_M3, step2_M3, step3_M3);
                break;
        }
    }

    // =====================================================
    // Misión 4
    // =====================================================
    void UpdateMission4UI()
    {
        if (mission4 == null) return;
        ResetColors(step1_M4, step2_M4, step3_M4, step4_M4);

        switch (mission4.currentState)
        {
            case MissionManagerM4.MissionState.SearchChild:
                Mark(step1_M4);
                Highlight(step2_M4);
                break;
            case MissionManagerM4.MissionState.FoundChild:
                Mark(step1_M4);
                Mark(step2_M4);
                Highlight(step3_M4);
                break;
            case MissionManagerM4.MissionState.FoundBear:
                Mark(step1_M4);
                Mark(step2_M4);
                Mark(step3_M4);
                Highlight(step4_M4);
                break;
            case MissionManagerM4.MissionState.Completed:
                MarkAll(step1_M4, step2_M4, step3_M4, step4_M4);
                break;
        }
    }

    // =====================================================
    // Misión Final (Yaffi)
    // =====================================================
    void UpdateMissionFinalUI()
    {
        if (missionFinal == null) return;
        ResetColors(step1_Final, step2_Final, step3_Final);

        switch (missionFinal.currentState)
        {
            case MissionManagerFinal.MissionState.TalkedToYaffy:
                Highlight(step1_Final);
                break;
            case MissionManagerFinal.MissionState.FoundCollar:
                Mark(step1_Final);
                Highlight(step2_Final);
                break;
            case MissionManagerFinal.MissionState.ReturnedCollar:
                Mark(step1_Final);
                Mark(step2_Final);
                Highlight(step3_Final);
                break;
            case MissionManagerFinal.MissionState.MissionComplete:
                MarkAll(step1_Final, step2_Final, step3_Final);
                break;
        }

    }

    // =====================================================
    // UTILIDADES DE COLOR Y MARCADO
    // =====================================================
    void Mark(TextMeshProUGUI text)
    {
        if (text == null) return;
        text.text = $"<s>{text.text}</s>";
        text.color = Color.gray;
    }

    void Highlight(TextMeshProUGUI text)
    {
        if (text == null) return;
        text.color = Color.cyan;
    }

    void MarkAll(params TextMeshProUGUI[] texts)
    {
        foreach (var t in texts)
        {
            if (t != null)
            {
                t.text = $"<s>{t.text}</s>";
                t.color = Color.gray;
            }
        }
    }

    void ResetColors(params TextMeshProUGUI[] texts)
    {
        foreach (var t in texts)
        {
            if (t != null)
            {
                t.color = Color.yellow;
            }
        }
    }
}
