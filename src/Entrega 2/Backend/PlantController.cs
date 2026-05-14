using UnityEngine;

public class PlantController : MonoBehaviour
{
    public enum PlantState { Yellow, Green, Black }
    public PlantState currentState = PlantState.Yellow;

    [HideInInspector] public int hydrationToday = -1;
    public int fertilizeDaysLeft = 2;

    [Header("Modelos — arraste cada filho aqui")]
    public GameObject modelYellow;   // PlantaAmarela_Model
    public GameObject modelGreen;    // PlantaVerde_Model
    public GameObject modelBlack;    // PlantaMurcha_Model

    void Start() => ApplyVisual();

    public bool TrySetWater(int cups)
    {
        if (fertilizeDaysLeft <= 0) return false;
        hydrationToday = Mathf.Clamp(cups, 0, 2);
        return true;
    }

    public void Fertilize()
    {
        fertilizeDaysLeft = 2;
    }

    public int OnDayPassed()
    {
        int scoreDelta = 0;

        if (hydrationToday == 0)
        {
            scoreDelta = -1;
            if (currentState == PlantState.Green)
                currentState = PlantState.Yellow;
        }
        else if (hydrationToday == 1)
        {
            scoreDelta = 0;
        }
        else if (hydrationToday == 2)
        {
            scoreDelta = +1;
            currentState = PlantState.Green;
            PlayerStats.Instance.DecreaseHydration();
        }

        if (fertilizeDaysLeft > 0)
            fertilizeDaysLeft--;

        ApplyVisual();
        hydrationToday = -1;
        return scoreDelta;
    }

    public void ForceKill()
    {
        currentState = PlantState.Black;
        ApplyVisual();
    }

    void ApplyVisual()
    {
        if (modelYellow != null) modelYellow.SetActive(currentState == PlantState.Yellow);
        if (modelGreen != null) modelGreen.SetActive(currentState == PlantState.Green);
        if (modelBlack != null) modelBlack.SetActive(currentState == PlantState.Black);
    }
}