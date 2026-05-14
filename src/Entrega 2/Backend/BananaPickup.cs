using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    [Header("Interação")]
    public float interactionRange = 2.5f;
    public Transform player;
    public GameObject promptUI;

    public int respawnEvery = 2;

    private bool playerInRange = false;

    void Update()
    {
        if (!gameObject.activeSelf) return;

        float dist = Vector3.Distance(player.position, transform.position);
        playerInRange = dist <= interactionRange && !Inventory.Instance.hasBanana;

        if (promptUI != null)
            promptUI.SetActive(playerInRange);

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    void PickUp()
    {
        Inventory.Instance.PickUpBanana();
        gameObject.SetActive(false);
        if (promptUI != null) promptUI.SetActive(false);
    }

    // Chamado pelo DayCycleManager a cada novo dia
    // Lógica simplificada: aparece nos dias ímpares (1, 3, 5)
    // ou seja, sempre que o jogador precisaria adubar
    public void TryRespawn(int currentDay)
    {
        if (Inventory.Instance.hasBanana) return;

        // Aparece no dia 1 e a cada 'respawnEvery' dias depois
        // Dia 1: aparece. Dia 2: some. Dia 3: aparece. Dia 4: some...
        if (currentDay == 1 || (currentDay - 1) % respawnEvery == 0)
        {
            gameObject.SetActive(true);
            if (promptUI != null) promptUI.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
