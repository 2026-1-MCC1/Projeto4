using UnityEngine;

public class PlantingSpot : MonoBehaviour
{
    public Transform player;
    public GameObject promptUI;
    public GameObject plantObject;
    public float interactionRange = 2f;

    private bool planted = false;

    void Update()
    {
        if (planted) return;

        float dist = Vector3.Distance(player.position, transform.position);
        bool inRange = dist <= interactionRange && Inventory.Instance.hasSeedling;

        if (promptUI != null) promptUI.SetActive(inRange);

        if (inRange && Input.GetKeyDown(KeyCode.E))
            Plant();
    }

    void Plant()
    {
        planted = true;
        Inventory.Instance.UseSeedling();
        if (promptUI != null) promptUI.SetActive(false);

        if (plantObject != null) plantObject.SetActive(true);

        // Chama o ProloguManager — ele controla a frase e libera a cama
        ProloguManager.Instance.OnSeedlingPlanted();
    }
}
