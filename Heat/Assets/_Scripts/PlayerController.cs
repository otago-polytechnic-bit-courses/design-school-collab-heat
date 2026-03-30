using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 4;
    //[SerializeField] GameObject Player;
    
       public static PlayerController Instance;
    private Vector2 movement;
  
    private Camera mainCamera;

    public int currentHealth;

    public float energyLoss = 50;

    public int playerCoal = 0;
    
   
    private void Start()
    {
        currentHealth = 6000;
        mainCamera = Camera.main;    
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
  
    // Correct signature: Collision2D for 2D physics
    //private void OnCollisionEnter2D(Collision2D collision)
   //{
   //     playerCoal += 1;
   // }

}