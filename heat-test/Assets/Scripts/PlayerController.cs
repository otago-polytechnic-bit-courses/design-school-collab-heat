using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;

    [Header("Coal and Furnace")]
    [SerializeField] public TextMeshProUGUI coalCounterText;
    private float coalNum = 0f;
    [SerializeField] public float coalIncrement = 10f;
    [SerializeField] public GameObject furnace;
    [SerializeField] ProgressBarController progress;

    private CharacterController controller;
    private Vector3 moveInput;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log($"Move input: {moveInput}");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log($"Jumping: {context.performed} - Is Grounded: {controller.isGrounded}");
        if(context.performed && controller.isGrounded)
        {
            Debug.Log("Jumped!");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Update()
    {
        //Move logic
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);


        //Jump logic
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Coal number
        coalCounterText.SetText($"{coalNum.ToString()}");
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision works");

        //Pick up coal
        if (collision.gameObject.CompareTag("Coal"))
        {
            Debug.Log("Coal tag works");
            coalNum += coalIncrement;
        }

        //Deposit coal in furnace, refill heat meter and upgrade meter max by how much coal is deposited
        if (collision.gameObject.CompareTag("Furnace"))
        {
            Debug.Log("Furance tag works");
            if (coalNum > 0)
            {
                Debug.Log("Player has coal");
                progress.maxValue += coalNum;
                progress.ResetBar();
                coalNum = 0f;
            }


        }
    }



}