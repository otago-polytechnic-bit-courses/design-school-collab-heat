using UnityEngine;

public class CoalController : MonoBehaviour
{
    [SerializeField] public float totalCoal;

    public static CoalController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if(totalCoal <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Coal()
    {
        //Player picks up coal
    }
}
