using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    // Adiciona dentro do Inventory.cs existente:

    [Header("HUD — muda")]
    public bool hasSeedling = false;
    public GameObject seedlingIcon;
    public TMPro.TMP_Text seedlingLabel;

    public void PickUpSeedling() { hasSeedling = true; UpdateHUD(); }
    public void UseSeedling() { hasSeedling = false; UpdateHUD(); }

    // Dentro do UpdateHUD() existente, adiciona:
    // if (seedlingIcon  != null) seedlingIcon.SetActive(hasSeedling);
    // if (seedlingLabel != null) seedlingLabel.text = hasSeedling ? "Muda" : "";

    [Header("Estado")]
    public bool hasMug = false;
    public bool hasBanana = false;

    [Header("HUD — caneca")]
    public GameObject mugIcon;
    public TMP_Text mugLabel;

    [Header("HUD — banana")]
    public GameObject bananaIcon;
    public TMP_Text bananaLabel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Caneca
    public void PickUpMug() { hasMug = true; UpdateHUD(); }
    public void UseMug() { hasMug = false; UpdateHUD(); }

    // Banana
    public void PickUpBanana() { hasBanana = true; UpdateHUD(); }
    public void UseBanana() { hasBanana = false; UpdateHUD(); }

    void UpdateHUD()
    {
        if (mugIcon != null) mugIcon.SetActive(hasMug);
        if (mugLabel != null) mugLabel.text = hasMug ? "Caneca" : "";

        if (bananaIcon != null) bananaIcon.SetActive(hasBanana);
        if (bananaLabel != null) bananaLabel.text = hasBanana ? "Banana" : "";
    }
}
