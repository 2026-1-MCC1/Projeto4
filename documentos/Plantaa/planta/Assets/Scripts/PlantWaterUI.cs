using UnityEngine;
using UnityEngine.UI;

public class PlantWaterUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject waterPanel;           // O painel que contém os 3 botões
    public Button button0;                  // Botão "Dar 0"
    public Button button1;                  // Botão "Dar 1"
    public Button button2;                  // Botão "Dar 2"

    private PlantGrowth plant;              // Referência à planta
    private bool isNearPlant = false;

    private void Start()
    {
        waterPanel.SetActive(false);        // Começa escondido

        // Conecta os botões
        button0.onClick.AddListener(() => GiveWater(0));
        button1.onClick.AddListener(() => GiveWater(1));
        button2.onClick.AddListener(() => GiveWater(2));
    }

    // Chamado quando o jogador entra na área da planta
    public void ShowUI(PlantGrowth plantScript)
    {
        plant = plantScript;
        waterPanel.SetActive(true);
        isNearPlant = true;
    }

    // Chamado quando o jogador sai da área da planta
    public void HideUI()
    {
        waterPanel.SetActive(false);
        isNearPlant = false;
    }

    // Função que dá a água e esconde a UI
    private void GiveWater(int amount)
    {
        if (plant != null)
        {
            plant.ReceiveWater(amount);                    // Planta recebe a água
            GameManager.Instance.RegisterWater(amount);    // GameManager registra para o dia
        }

        HideUI();
        Debug.Log("Jogador deu " + amount + " caneca(s) para a planta");
    }

    // Atualiza todo frame (verifica se apertou ESC para fechar)
    private void Update()
    {
        if (isNearPlant && Input.GetKeyDown(KeyCode.Escape))
        {
            HideUI();
        }
    }
}