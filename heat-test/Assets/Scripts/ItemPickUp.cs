using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] public bool isDrill;
    [SerializeField] public bool isPick;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isDrill)
            {
                PlayerController.Instance.hasDrill = true;
            }
            else if (isPick)
            {
                PlayerController.Instance.hasPick = true;
            }

            Destroy(gameObject);
        }
    }
}
