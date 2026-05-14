using UnityEngine;
using TMPro;
using System.Collections;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager Instance;

    [Header("Painel de narrativa")]
    public GameObject narrativePanel;
    public TMP_Text narrativeText;
    public TMP_Text continueHint;

    private bool waitingForInput = false;
    private bool isShowing = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // ── Exibição principal ───────────────────────────────────────────────
    public void Show(string phrase, System.Action onDone = null)
    {
        if (isShowing) return;   // evita sobreposição de chamadas
        StartCoroutine(ShowRoutine(phrase, onDone));
    }

    IEnumerator ShowRoutine(string phrase, System.Action onDone)
    {
        isShowing = true;

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

        narrativeText.text = "";
        narrativePanel.SetActive(true);

        if (continueHint != null)
            continueHint.gameObject.SetActive(false);

        yield return StartCoroutine(Typewrite(phrase));

        if (continueHint != null)
            continueHint.gameObject.SetActive(true);

        waitingForInput = true;
        yield return new WaitUntil(() => !waitingForInput);

        narrativePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isShowing = false;
        onDone?.Invoke();
    }

    IEnumerator Typewrite(string text)
    {
        narrativeText.text = "";
        foreach (char c in text)
        {
            narrativeText.text += c;
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }

    void Update()
    {
        if (waitingForInput && Input.anyKeyDown)
            waitingForInput = false;
    }

    // ── Helpers ─────────────────────────────────────────────────────────

    public void ShowWakePhrase(int day, int score)
    {
        if (day <= 3)
        {
            Show(NarrativeData.WakeFixed[day - 1]);
        }
        else
        {
            int col = ScoreToColumn(score);
            Show(NarrativeData.WakeDynamic[day - 4, col]);
        }
    }

    // Sem frase de dormir separada — o jogo vai direto para o próximo dia
    // Se quiser adicionar depois, basta chamar Show() antes do OnDayPassed()

    int ScoreToColumn(int score)
    {
        if (score <= -1) return 0;  // Silêncio
        if (score >= 3) return 2;  // Renascimento
        return 1;                   // Estagnação
    }
}