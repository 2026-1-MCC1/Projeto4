using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public int growthStage = 0;           // 0 = mudinha, 1 = média, 2 = grande
    public GameObject[] stageModels;      // Arraste 3 modelos aqui (Stage0, Stage1, Stage2)

    public bool hasNutrients = false;     // Casca de banana (adubo)
    public bool lightOn = true;           // Lâmpada do quarto

    public int waterToday = 0;            // Quantas canecas recebeu HOJE (0, 1 ou 2)
    public bool isDead = false;

    private const int WATER_NEEDED = 2;   // Precisa de 2 canecas por dia

    // Chamado quando a criança dá água
    public void ReceiveWater(int amount)
    {
        waterToday += amount;
        Debug.Log("Planta recebeu " + amount + " caneca(s) hoje");
    }

    // Chamado ao dormir (avançar o dia)
    public void CheckDailyGrowth()
    {
        if (isDead) return;

        bool conditionsMet = hasNutrients && lightOn && waterToday >= WATER_NEEDED;

        if (conditionsMet)
        {
            growthStage = Mathf.Min(growthStage + 1, 2);
            UpdateVisual();
            Debug.Log("Planta cresceu! Estágio: " + growthStage);
        }
        else
        {
            if (growthStage > 0) growthStage--;
            UpdateVisual();
            Debug.Log("Planta não cresceu");

            if (growthStage <= -1)
            {
                isDead = true;
                Debug.Log("A planta morreu...");
            }
        }

        waterToday = 0; // Reseta para o próximo dia
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < stageModels.Length; i++)
        {
            if (stageModels[i] != null)
                stageModels[i].SetActive(i == growthStage);
        }
    }

    public void AddNutrients()
    {
        hasNutrients = true;
        Debug.Log("Nutrientes adicionados");
    }
}