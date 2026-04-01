using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI EnergyLoss;
    public TextMeshProUGUI HeatEnergy;
     public TextMeshProUGUI HeatCoal;
    

    void Update()
    {
        HeatEnergy.text = "Energy: " + playerController.currentHealth;
        HeatCoal.text = "Coal: " + playerController.playerCoal;
        EnergyLoss.text = "Energy Drain: " + playerController.energyLoss;
    }
}