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

    public int currentHealth;

    public float energyLoss = 100;

    public int playerCoal;
    
   
    private void Start()
    {
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
        Debug.Log(playerCoal);
        if (movement.magnitude > 0) // player is moving
        {
            currentHealth -= Mathf.RoundToInt(energyLoss * Time.deltaTime);
            currentHealth = Mathf.Max(currentHealth, 0); // prevent negative health
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
    }

}