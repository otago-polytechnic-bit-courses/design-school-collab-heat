using UnityEngine;

public class IsometriicFollowCamera : MonoBehaviour
{
    [Header("Target Tracking")]
    public Transform playerTarget;
    public float smoothSpeed = 5f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 5f;
    private float targetAngle = -45f; 
    private float currentAngle = -45f;

    
    private float heightOffset = 10f;
    private float distanceOffset = 14.14f; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q)) targetAngle += 90f;
        if (Input.GetKeyDown(KeyCode.E)) targetAngle -= 90f;
    }

    void LateUpdate()
    {
        if (playerTarget != null)
        {
            
            currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

            
            float radians = currentAngle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians)) * distanceOffset;
            offset.y = heightOffset;

            
            transform.position = playerTarget.position + offset;
            transform.LookAt(playerTarget.position + Vector3.up);
        }
    }
}
