using UnityEngine;
using TMPro;

public class FertilizeInteraction : MonoBehaviour
{
    [Header("Referências")]
    public PlantController plant;
    public Transform player;

    [Header("Prompts")]
    public GameObject promptFertilize;   // "E — Adubar a terra"
    public TMP_Text messageText;       // texto temporário de feedback
    public GameObject messagePanel;      // painel do feedback

    [Header("Range")]
    public float interactionRange = 2.5f;

    private Coroutine hideMessageCoroutine;

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        bool inRange = dist <= interactionRange;

        // Mostra prompt de adubar só se tiver banana E terra precisar de adubo
        bool canFertilize = inRange
                         && Inventory.Instance.hasBanana
                         && plant.fertilizeDaysLeft <= 0;

        if (promptFertilize != null)
            promptFertilize.SetActive(canFertilize);

        if (canFertilize && Input.GetKeyDown(KeyCode.E))
            DoFertilize();
    }

    void DoFertilize()
    {
        plant.Fertilize();
        Inventory.Instance.UseBanana();

        if (promptFertilize != null)
            promptFertilize.SetActive(false);

        ShowMessage("Terra adubada! Agora você pode regar.");
    }

    // Chamado pelo WaterUI quando rega é bloqueada
    public void ShowBlockedMessage()
    {
        ShowMessage("Preciso adubar a terra antes de regá-la.");
    }

    public void ShowMessage(string msg)
    {
        if (messageText != null) messageText.text = msg;
        if (messagePanel != null) messagePanel.SetActive(true);

        if (hideMessageCoroutine != null)
            StopCoroutine(hideMessageCoroutine);

        hideMessageCoroutine = StartCoroutine(HideAfterDelay(3f));
    }

    System.Collections.IEnumerator HideAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (messagePanel != null) messagePanel.SetActive(false);
    }
}