using UnityEngine;

public class CoalController : MonoBehaviour
{
    [SerializeField] public float totalCoal;

    public static CoalController Instance;

    void Update()
    {
        if(totalCoal <= 0)
        {
            Debug.Log("0 Coal Left");
            Destroy(gameObject);
        }
    }

    void Coal()
    {
        //Player picks up coal
    }
}
