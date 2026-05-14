using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject endingPanel;
    public TMP_Text endingTitle;
    public TMP_Text endingMessage;
    public PlantController plant;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Score vai de -6 a +6 em 6 dias
    public void EvaluateEnding(int score)
    {
        StartCoroutine(ShowEnding(score));
    }

    IEnumerator ShowEnding(int score)
    {
        yield return new WaitForSeconds(1.5f);

        if (score >= 3)
        {
            // Final Renascimento
            endingTitle.text = "Renascimento";
            endingMessage.text = NarrativeData.EndingGood;
        }
        else if (score <= -2)
        {
            // Final Silêncio
            plant.ForceKill();
            endingTitle.text = "Silêncio";
            endingMessage.text = NarrativeData.EndingBad;
        }
        else
        {
            // Final Estagnação
            endingTitle.text = "Estagnação";
            endingMessage.text = NarrativeData.EndingNeutral;
        }

        endingPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}