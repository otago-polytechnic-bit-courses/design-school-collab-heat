using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] public bool isDrill;
    [SerializeField] public bool isPick;

    // Use OnTriggerEnter — works with CharacterController
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isDrill)
            {
                PlayerController.Instance.PickUpDrill();
                Debug.Log("Drill destory");
            }
            else if (isPick)
            {
                PlayerController.Instance.PickUpPick();
            }
            Destroy(gameObject);
        }
    }
}