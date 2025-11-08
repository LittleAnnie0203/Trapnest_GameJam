using UnityEngine;
using TMPro;

public class MissionUIManager : MonoBehaviour
{
    [Header("Referencias a los MissionManagers")]
    public MissionManager mission1;        // objeto que tiene MissionManager
    public MissionManagerM3 mission3;      // objeto con MissionManagerM3
    public MissionManagerM4 mission4;      // objeto con MissionManagerM4

    [Header("TextMeshPro - Misión 1 (Manilla)")]
    public TextMeshProUGUI step1_M1;
    public TextMeshProUGUI step2_M1;
    public TextMeshProUGUI step3_M1;

    [Header("TextMeshPro - Misión 3 (Carta)")]
    public TextMeshProUGUI step1_M3;
    public TextMeshProUGUI step2_M3;
    public TextMeshProUGUI step3_M3;

    [Header("TextMeshPro - Misión 4 (Madre/niño/osito)")]
    public TextMeshProUGUI step1_M4;
    public TextMeshProUGUI step2_M4;
    public TextMeshProUGUI step3_M4;
    public TextMeshProUGUI step4_M4;

    // Guardamos textos originales para no modificar el texto base permanentemente
    private string o_step1_M1, o_step2_M1, o_step3_M1;
    private string o_step1_M3, o_step2_M3, o_step3_M3;
    private string o_step1_M4, o_step2_M4, o_step3_M4, o_step4_M4;

    void Awake()
    {
        // Guardar textos originales
        if (step1_M1 != null) o_step1_M1 = step1_M1.text;
        if (step2_M1 != null) o_step2_M1 = step2_M1.text;
        if (step3_M1 != null) o_step3_M1 = step3_M1.text;

        if (step1_M3 != null) o_step1_M3 = step1_M3.text;
        if (step2_M3 != null) o_step2_M3 = step2_M3.text;
        if (step3_M3 != null) o_step3_M3 = step3_M3.text;

        if (step1_M4 != null) o_step1_M4 = step1_M4.text;
        if (step2_M4 != null) o_step2_M4 = step2_M4.text;
        if (step3_M4 != null) o_step3_M4 = step3_M4.text;
        if (step4_M4 != null) o_step4_M4 = step4_M4.text;
    }

    void Update()
    {
        UpdateMission1UI();
        UpdateMission3UI();
        UpdateMission4UI();
    }

    // ---------- Misión 1 ----------
    void UpdateMission1UI()
    {
        if (mission1 == null) return;

        // Reseteamos antes de aplicar
        ResetTexts(step1_M1, step2_M1, step3_M1, o_step1_M1, o_step2_M1, o_step3_M1);

        switch (mission1.currentState)
        {
            case MissionManager.MissionState.NotStarted:
                // nada marcado
                break;
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

    // ---------- Misión 3 ----------
    void UpdateMission3UI()
    {
        if (mission3 == null) return;

        ResetTexts(step1_M3, step2_M3, step3_M3, o_step1_M3, o_step2_M3, o_step3_M3);

        switch (mission3.currentState)
        {
            case MissionManagerM3.MissionState.None:
                break;
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

    // ---------- Misión 4 ----------
    void UpdateMission4UI()
    {
        if (mission4 == null) return;

        ResetTexts(step1_M4, step2_M4, step3_M4, step4_M4, o_step1_M4, o_step2_M4, o_step3_M4, o_step4_M4);

        switch (mission4.currentState)
        {
            case MissionManagerM4.MissionState.NotStarted:
                break;
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

    // ---------- Funciones auxiliares ----------
    void Mark(TextMeshProUGUI text)
    {
        if (text == null) return;
        text.text = $"<s>{text.text}</s>";
        text.color = Color.gray;
    }

    void Highlight(TextMeshProUGUI text)
    {
        if (text == null) return;
        // color amarillo para paso activo
        text.color = Color.cyan;
    }

    void MarkAll(params TextMeshProUGUI[] texts)
    {
        foreach (var t in texts) if (t != null) { t.text = $"<s>{t.text}</s>"; t.color = Color.gray; }
    }

    // Reset que devuelve los textos a los originales (evita múltiples <s> o colores acumulados)
    void ResetTexts(TextMeshProUGUI t1, TextMeshProUGUI t2, TextMeshProUGUI t3,
                    string o1, string o2, string o3)
    {
        if (t1 != null) { t1.text = o1; t1.color = Color.yellow; }
        if (t2 != null) { t2.text = o2; t2.color = Color.yellow; }
        if (t3 != null) { t3.text = o3; t3.color = Color.yellow; }
    }

    // Sobrecarga para 4 textos
    void ResetTexts(TextMeshProUGUI t1, TextMeshProUGUI t2, TextMeshProUGUI t3, TextMeshProUGUI t4,
                    string o1, string o2, string o3, string o4)
    {
        if (t1 != null) { t1.text = o1; t1.color = Color.yellow; }
        if (t2 != null) { t2.text = o2; t2.color = Color.yellow; }
        if (t3 != null) { t3.text = o3; t3.color = Color.yellow; }
        if (t4 != null) { t4.text = o4; t4.color = Color.yellow; }
    }
}
