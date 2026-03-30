using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI HeatEnergy;

    void Update()
    {
        HeatEnergy.text = "Energy: " + playerController.currentHealth;
    }
}