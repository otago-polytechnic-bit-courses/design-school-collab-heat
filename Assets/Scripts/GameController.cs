using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] TextMeshProUGUI coalPickedUpText;
    [SerializeField] GameObject player;

    int coalCount = 0;

    private void Update()
    {
        healthBar.value += Time.deltaTime;

        if (healthBar.value >= healthBar.maxValue)
        {
            player.SetActive(false);
        }

        if (coalPickedUpText.text != "Coal Picked Up: " + coalCount)
        {
            coalPickedUpText.text = "Coal Picked Up: " + coalCount;
        }
    }

    public void FillHealthBar()
    {
        healthBar.value -= Time.deltaTime * 20f; //Slowly health to max
    }

    public void SlightlyFillHealthBar()
    {
        healthBar.value -= 5.0f; //Change value based on max health/slider value
        coalCount++;
    }

}

