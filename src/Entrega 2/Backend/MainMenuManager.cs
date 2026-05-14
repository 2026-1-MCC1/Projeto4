using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject menuPanel;
    public GameObject creditsPanel;

    void Start()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Botão Jogar
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // coloca o nome exato da sua cena do jogo
    }

    // Botão Créditos
    public void OpenCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Botão Voltar (dentro do painel de créditos)
    public void CloseCredits()
    {
        creditsPanel.SetActive(true);
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}