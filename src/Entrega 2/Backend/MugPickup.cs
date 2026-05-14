using UnityEngine;
using TMPro;

public class MugPickup : MonoBehaviour
{
    [Header("Interação")]
    public float interactionRange = 2.5f;
    public Transform player;

    [Header("Prompt")]
    public GameObject promptUI;   // GameObject com texto "E — Pegar caneca"

    private bool playerInRange = false;

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        playerInRange = dist <= interactionRange && !Inventory.Instance.hasMug;

        if (promptUI != null)
            promptUI.SetActive(playerInRange);

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    void PickUp()
    {
        Inventory.Instance.PickUpMug();
        gameObject.SetActive(false);   // some do mundo
        if (promptUI != null) promptUI.SetActive(false);
    }

    // Chamado pelo DayCycleManager ao acordar (respawn diário)
    public void Respawn()
    {
        if (!Inventory.Instance.hasMug)
            gameObject.SetActive(true);
    }
}