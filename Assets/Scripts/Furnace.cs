using UnityEngine;

public class Furnace : MonoBehaviour
{

    [SerializeField] GameObject pickup;
    [SerializeField] GameController gameController;

    bool isNearFurnace = false;
    

    private void Update()
    {
        if (isNearFurnace)
        {
            gameController.FillHealthBar();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        
        isNearFurnace = true;
    }



    private void OnTriggerExit(Collider other)
    {
        isNearFurnace = false;
    }
}
