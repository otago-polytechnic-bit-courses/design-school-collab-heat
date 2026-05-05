using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeatMod;
    [SerializeField] private float moveHeatMod;

    [Header("Coal and Furnace")]
    [SerializeField] public TextMeshProUGUI coalCounterText;
    private float coalNum = 0f;
    [SerializeField] public float coalIncrement = 10f;
    [SerializeField] public GameObject furnace;
    [SerializeField] ProgressBarController progress;
    [SerializeField] CoalController coalController;

    [Header("Misc")]
    [SerializeField] public bool hasDrill = false;
    [SerializeField] public GameObject drill;
    [SerializeField] public bool hasPick = false;
    [SerializeField] public GameObject pick;

    private CharacterController controller;
    private Vector3 moveInput;
    private Vector3 velocity;

    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if (!hasDrill)
        {
            drill.SetActive(false);
        }

        if (!hasPick)
        {
            pick.SetActive(false);
        }
    }

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

    public void PickUpDrill()
    {
        hasDrill = true;
        drill.SetActive(true);
        Debug.Log("Drill is true");
    }

    public void PickUpPick()
    {
        hasPick = true;
        pick.SetActive(true);
    }

    void Update()
    {
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        //Move logic
        Vector3 move = camForward * moveInput.y + camRight * moveInput.x;
        controller.Move(move * speed * Time.deltaTime);


        //Jump logic
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Coal number
        coalCounterText.SetText($"{coalNum.ToString()}");

        //Heat meter reduction
        if (velocity.y > 0.01f)
        {
            //Jump makes it decrease faster
            progress.Decrease(Time.deltaTime * jumpHeatMod);
        }
        else if (moveInput.sqrMagnitude > 0.01f)
        {
            // Decreases when player is moving
            progress.Decrease(Time.deltaTime * moveHeatMod);
        }


        
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision works");

        //Pick up coal
        if (collision.gameObject.CompareTag("Coal") && hasPick == true)
        {
            Debug.Log("Coal tag works");
            coalNum += coalIncrement;
            coalController.totalCoal -= coalIncrement;
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