using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI HeatEnergy;

     public TextMeshProUGUI HeatCoal;
    

    void Update()
    {
        HeatEnergy.text = "Energy: " + playerController.currentHealth;
        HeatCoal.text = "Energy: " + playerController.playerCoal;
    }
}