using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] GameObject Player;
    
       public static PlayerController Instance;
    private Vector2 movement;
  
    private Camera mainCamera;
   

    private void Start()
    {
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
        Vector3 mousePosition = Input.mousePosition;
        Vector3 cursorPoint = mainCamera.WorldToScreenPoint(transform.localPosition);

        if (mousePosition.x < cursorPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
        }


       

        // Player movement

        Vector2 offset = new Vector2(mousePosition.x - cursorPoint.x, mousePosition.y - cursorPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

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