using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Range(0f, 100f)]
    public float hydration = 100f;
    public float hydrationLossPerDay = 14f; // 7 dias de 2 copos = zera exato

    public Slider hydrationBar;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void DecreaseHydration()
    {
        hydration = Mathf.Max(0f, hydration - hydrationLossPerDay);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (hydrationBar != null)
            hydrationBar.value = hydration / 100f;
    }
}