using UnityEngine;
using TMPro;

public class WaterUI : MonoBehaviour
{
    [Header("Referências")]
    public GameObject uiPanel;
    public PlantController plant;
    public FertilizeInteraction fertilize;   // para chamar a mensagem de bloqueio

    [Header("Interação")]
    public float interactionRange = 2.5f;
    public Transform player;

    [Header("Prompts")]
    public GameObject promptInteract;   // "E — Regar a planta"
    public GameObject promptNoMug;      // "Você precisa da caneca"

    private bool panelOpen = false;

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        bool inRange = dist <= interactionRange;
        bool hasMug = Inventory.Instance.hasMug;
        bool soilOk = plant.fertilizeDaysLeft > 0;
        bool watered = plant.hydrationToday != -1;

        // Apaga TODOS os prompts primeiro
        if (promptInteract != null) promptInteract.SetActive(false);
        if (promptNoMug != null) promptNoMug.SetActive(false);

        // Depois ativa só o correto
        if (inRange && !panelOpen && !watered)
        {
            if (hasMug)
            {
                if (promptInteract != null) promptInteract.SetActive(true);
            }
            else
            {
                if (promptNoMug != null) promptNoMug.SetActive(true);
            }
        }

        if (inRange && hasMug && Input.GetKeyDown(KeyCode.E) && !panelOpen && !watered)
        {
            if (!soilOk)
                fertilize.ShowBlockedMessage();
            else
                OpenPanel();
        }

        if (panelOpen && Input.GetKeyDown(KeyCode.Escape))
            ClosePanel();
    }

    void OpenPanel()
    {
        panelOpen = true;
        uiPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ClosePanel()
    {
        panelOpen = false;
        uiPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GiveZeroCups() { plant.TrySetWater(0); Inventory.Instance.UseMug(); ClosePanel(); }
    public void GiveOneCup() { plant.TrySetWater(1); Inventory.Instance.UseMug(); ClosePanel(); }
    public void GiveTwoCups() { plant.TrySetWater(2); Inventory.Instance.UseMug(); ClosePanel(); }
}