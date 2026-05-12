using UnityEngine;

public class SaltController : MonoBehaviour
{
    [SerializeField] public float totalSalt;

    public static SaltController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.Log("Else");
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (totalSalt <= 0)
        {
            Debug.Log("0 Salt Left");
            Destroy(gameObject);
        }
    }

    void Salt()
    {
        //Player picks up coal
    }
}
