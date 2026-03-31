using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickup;
    [SerializeField] PlayerController playerController;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            if (pickup.CompareTag("Coal"))
            {
                playerController.SlightlyFillHealthBar();
            }
            else if (pickup.CompareTag("Crystal"))
            {
                playerController.AddCrystal();
            }

            Destroy(pickup);
        }
    }
}
