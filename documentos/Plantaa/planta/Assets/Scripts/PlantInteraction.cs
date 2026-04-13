using UnityEngine;

public class PlantInteraction : MonoBehaviour
{
    public PlantWaterUI waterUI;           // Arraste o WaterPanel aqui

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterUI.ShowUI(GetComponent<PlantGrowth>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterUI.HideUI();
        }
    }
}