using UnityEngine;
using UnityEngine.InputSystem; 


public class PlayerController : MonoBehaviour
{
    float moveSpeed = 10f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 moveInput;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        controller.Move(move * Time.deltaTime * moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

}
