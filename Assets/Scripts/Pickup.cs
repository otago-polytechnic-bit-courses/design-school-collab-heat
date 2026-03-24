using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] GameObject pickup;
    [SerializeField] GameController gameController;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            gameController.SlightlyFillHealthBar();
            Destroy(pickup);
        }
    }
}
