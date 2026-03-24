using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] GameObject player;

    private void Update()
    {
        healthBar.value += Time.deltaTime;

        if (healthBar.value >= healthBar.maxValue)
        {
            player.SetActive(false);
        }
    }

    public void FillHealthBar()
    {
        healthBar.value = 0.0f; //Sets health to max
    }

    public void SlightlyFillHealthBar()
    {
        healthBar.value -= 5.0f; //Change value based on max health/slider value
    }

}

