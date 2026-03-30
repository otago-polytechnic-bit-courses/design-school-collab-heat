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

}