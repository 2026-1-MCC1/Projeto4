using UnityEngine;
using TMPro;                    // ← Mudamos para TextMeshPro

public class PlayerHydration : MonoBehaviour
{
    public int hydrationDays = 5;
    public TextMeshProUGUI hydrationText;   // TextMeshProUGUI

    public void CheckDehydration(int waterGivenToPlant)
    {
        if (waterGivenToPlant >= 2)
        {
            hydrationDays--;
            Debug.Log("Criança deu toda a água → hidratação -1 (restam " + hydrationDays + " dias)");
        }
        else if (waterGivenToPlant == 1)
        {
            Debug.Log("Deu 1 caneca → hidratação estável");
        }
        else
        {
            if (hydrationDays < 5)
            {
                hydrationDays++;
                Debug.Log("Recuperou hidratação");
            }
        }

        // Atualiza o texto
        if (hydrationText != null)
        {
            hydrationText.text = "Hidratação: " + hydrationDays + " dias";

            if (hydrationDays <= 2)
                hydrationText.color = Color.red;
            else if (hydrationDays <= 3)
                hydrationText.color = Color.yellow;
            else
                hydrationText.color = Color.green;
        }

        if (hydrationDays <= 0)
        {
            Debug.Log("CRIANÇA MORREU DE DESIDRATAÇÃO");
        }
    }
}