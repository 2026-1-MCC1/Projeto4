using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public float interactionRange = 2.5f;
    public Transform player;
    public GameObject promptUI;

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        bool inRange = dist <= interactionRange;

        if (promptUI != null) promptUI.SetActive(inRange);

        if (inRange && Input.GetKeyDown(KeyCode.E))
            DayCycleManager.Instance.SleepAndPassDay();
    }
}