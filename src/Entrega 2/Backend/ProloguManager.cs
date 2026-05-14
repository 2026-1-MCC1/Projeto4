using UnityEngine;
using System.Collections;

public class ProloguManager : MonoBehaviour
{
    public static ProloguManager Instance;

    public BedInteraction bedInteraction;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (bedInteraction != null)
            bedInteraction.enabled = false;

        StartCoroutine(StartPrologue());
    }

    IEnumerator StartPrologue()
    {
        // Mostra Dia 0 no HUD
        if (DayCycleManager.Instance.dayCounterText != null)
            DayCycleManager.Instance.dayCounterText.text = "Dia 0";

        yield return new WaitForSecondsRealtime(0.5f);
        NarrativeManager.Instance.Show(NarrativeData.PrologueOpening);
    }

    public void OnSeedlingFound()
    {
        NarrativeManager.Instance.Show(NarrativeData.PrologueFoundSeedling);
    }

    public void OnSeedlingPlanted()
    {
        NarrativeManager.Instance.Show(NarrativeData.ProloguePlanted, () =>
        {
            NarrativeManager.Instance.Show(NarrativeData.PrologueReadyToSleep, () =>
            {
                if (bedInteraction != null)
                    bedInteraction.enabled = true;
            });
        });
    }

    public void PrologueSleep()
    {
        NarrativeManager.Instance.Show(NarrativeData.PrologueBeforeSleep, () =>
        {
            // StartGame já cuida de mostrar a frase do dia 1
            DayCycleManager.Instance.StartGame();
        });
    }
}