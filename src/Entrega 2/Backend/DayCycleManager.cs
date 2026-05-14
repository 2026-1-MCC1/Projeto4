using UnityEngine;
using System.Collections;

public class DayCycleManager : MonoBehaviour
{
    public static DayCycleManager Instance;

    public int currentDay = 0;   // começa no prólogo
    public int totalDays = 6;
    public int score = 0;

    public PlantController plant;
    public MugPickup mugPickup;
    public BananaPickup bananaPickup;

    [Header("UI")]
    public TMPro.TMP_Text dayCounterText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Chamado pela cama — decide sozinho o que fazer
    public void SleepAndPassDay()
    {
        // Dia 0 = prólogo, não precisa interagir com a planta
        if (currentDay == 0)
        {
            ProloguManager.Instance.PrologueSleep();
            return;
        }

        // Dias 1-6 = jogo normal
        if (plant.hydrationToday == -1)
        {
            FeedbackMessage("Interaja com a planta antes de dormir.");
            return;
        }

        int delta = plant.OnDayPassed();
        score += delta;
        currentDay++;
        UpdateDayUI();

        if (currentDay > totalDays)
        {
            GameManager.Instance.EvaluateEnding(score);
        }
        else
        {
            if (mugPickup != null) mugPickup.Respawn();
            if (bananaPickup != null) bananaPickup.TryRespawn(currentDay);

            StartCoroutine(ShowWakeAfterDelay(currentDay, score));
        }
    }

    // Chamado pelo ProloguManager para iniciar o dia 1
    public void StartGame()
    {
        currentDay = 1;
        score = 0;
        UpdateDayUI();

        if (mugPickup != null) mugPickup.Respawn();
        if (bananaPickup != null) bananaPickup.TryRespawn(currentDay);

        StartCoroutine(ShowWakeAfterDelay(currentDay, score));
    }

    IEnumerator ShowWakeAfterDelay(int day, int sc)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        NarrativeManager.Instance.ShowWakePhrase(day, sc);
    }

    public void UpdateDayUI()
    {
        if (dayCounterText != null)
            dayCounterText.text = $"Dia {currentDay} de {totalDays}";
    }

    void FeedbackMessage(string msg)
    {
        var fi = FindFirstObjectByType<FertilizeInteraction>();
        if (fi != null) fi.ShowMessage(msg);
    }
}
