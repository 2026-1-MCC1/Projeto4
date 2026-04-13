using UnityEngine;
using TMPro;                    // Para o texto de Dia X

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     // Permite que outros scripts acessem o GameManager

    public int currentDay = 1;
    public TextMeshProUGUI dayText;         // Texto "Dia X" na tela

    [Header("Referências dos outros scripts")]
    public PlantGrowth plant;               // Arraste a Planta aqui
    public PlayerHydration playerHydration; // Arraste o Player aqui
    public PlantWaterUI waterUI;            // Arraste o WaterPanel aqui

    private int waterGivenToday = 0;        // Quantas canecas foram dadas HOJE

    private void Awake()
    {
        Instance = this;                    // Cria o Singleton
    }

    // Chamado pela UI de canecas quando o jogador escolhe dar água
    public void RegisterWater(int amount)
    {
        waterGivenToday += amount;
        Debug.Log("GameManager registrou " + amount + " caneca(s) hoje");
    }

    // Chamado quando o jogador interage com a cama
    public void AdvanceDay()
    {
        currentDay++;
        dayText.text = "Dia " + currentDay;

        // 1. Verifica crescimento da planta
        plant.CheckDailyGrowth();

        // 2. Verifica se a criança ficou desidratada
        playerHydration.CheckDehydration(waterGivenToday);

        // Reseta para o próximo dia
        waterGivenToday = 0;

        // Verifica se o jogo acabou
        if (playerHydration.hydrationDays <= 0 || plant.isDead)
        {
            Debug.Log("=== FIM DO JOGO ===");
            // Aqui depois podemos mostrar tela de final (vamos fazer mais pra frente)
        }
    }
}
