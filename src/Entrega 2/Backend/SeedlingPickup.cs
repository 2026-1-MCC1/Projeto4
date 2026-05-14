using UnityEngine;

public class SeedlingPickup : MonoBehaviour
{
    public float interactionRange = 2f;
    public Transform player;
    public GameObject promptUI;
    public Light seedlingLight;
    public float lightIntensity = 0.4f;

    private bool collected = false;

    void Start()
    {
        if (seedlingLight != null)
            seedlingLight.intensity = lightIntensity;
    }

    void Update()
    {
        if (collected) return;

        float dist = Vector3.Distance(player.position, transform.position);
        bool inRange = dist <= interactionRange;

        if (promptUI != null) promptUI.SetActive(inRange);

        if (inRange && Input.GetKeyDown(KeyCode.E))
            Collect();
    }

    void Collect()
    {
        collected = true;
        if (promptUI != null) promptUI.SetActive(false);

        Inventory.Instance.PickUpSeedling();

        // Chama o ProloguManager — ele controla a frase
        ProloguManager.Instance.OnSeedlingFound();

        gameObject.SetActive(false);
    }
}