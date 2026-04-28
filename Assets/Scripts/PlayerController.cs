using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] TextMeshProUGUI resourceCountText;
    [SerializeField] GameObject player;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 moveInput;

    float moveSpeed = 10f;
    int coalCount = 0;
    int crystalCount = 0;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        controller.Move(move * Time.deltaTime * moveSpeed);
        
        if (moveInput.sqrMagnitude > 0.01f)
        {
            float drainRate = healthBar.maxValue * 0.01f; // 10% per second
            healthBar.value += drainRate * Time.deltaTime;
        }

        if (healthBar.value >= healthBar.maxValue)
        {
            player.SetActive(false);
        }

        if (resourceCountText.text != "Coal: " + coalCount + "\nCrystals: " + crystalCount)
        {
            resourceCountText.text = "Coal: " + coalCount + "\nCrystals: " + crystalCount;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
       
        
    }

    public void FillHealthBar()
    {
        healthBar.value -= Time.deltaTime * 5f; //Slowly health to max
    }

    public void SlightlyFillHealthBar()
    {
        healthBar.value -= 5.0f; //Change value based on max health/slider value
        coalCount++;
    }


    public void AddCrystal()
    {
        crystalCount++;
    }
}

