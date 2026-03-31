using UnityEngine;

public class Furnace : MonoBehaviour
{

    [SerializeField] GameObject furnace;
    [SerializeField] PlayerController PlayerController;

    bool isNearFurnace = false;
    

    private void Update()
    {
        if (isNearFurnace)
        {
            PlayerController.FillHealthBar();
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
