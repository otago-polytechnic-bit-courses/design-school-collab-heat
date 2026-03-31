using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float Heat = 10000;
    public int Coal;
    public float MaxHeat = 10000;
    public int speed = 10;
    [SerializeField] private Rigidbody2D rb; // Rigidbody for movement

    private Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal"); // Get input direction
        direction.Normalize();
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
        rb.linearVelocity = direction * speed; // Apply movement


        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (Heat <= 0)
            {
                speed = 0;
                Application.Quit();
            }
        }
        Heat -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coal"))
        {
            Coal++;
            Destroy(collision.gameObject);
            Debug.Log("Coal collected! Total coal: " + Coal);
        }
        if(collision.CompareTag("Furnace"))
        {
            Heat += Coal * 1000;
            Coal = 0;
            Debug.Log("Furnace refueled! Current heat: " + Heat);
        }
    }
}
