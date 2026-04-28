using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] GameObject Player;
    
    public static PlayerController Instance;
    private Vector2 movement;
  
    private Camera mainCamera;

    public float currentHealth;

    public float energyLoss = 70;

    public int playerCoal = 0;
    
   
    private void Start()
    {
        energyLoss = 70;
        currentHealth = 6000;
        mainCamera = Camera.main; 
        Debug.Log(playerCoal);   
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Debug.Log(playerCoal);
        if (movement.magnitude > 0.1f) // player is moving
        {
            currentHealth -= energyLoss * Time.deltaTime;
            currentHealth = Mathf.Max(currentHealth, 0); // prevent negative health
        }

        float currentSpeed = moveSpeed;

        if (movement.x != 0 && movement.y != 0)
        {
            currentSpeed /= 2;
        }
        rb.linearVelocity = movement.normalized * moveSpeed;

    }
    
    public void GameOver()
    {
        //AudioController.Instance.PlaySound("PlayerHit");
        Debug.Log("Game over method");
        Time.timeScale = 0f;
    }
  
    //Correct signature: Collision2D for 2D physics
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered with: " + collision.name);

        if (collision.CompareTag("CoalDeposit"))
        {
            Debug.Log("Coal detected");
            playerCoal += 1;
            Debug.Log("playerCoal");
        }

        if (collision.CompareTag("Furnace"))
        {
            Debug.Log("Furnace detected");
            if (playerCoal > 0)
            {
                playerCoal -= 1;
                energyLoss -= 10;
                energyLoss = Mathf.Max(energyLoss, 0);
                Debug.Log("Coal conerted to energy!");
            }
            

        }
    }

}