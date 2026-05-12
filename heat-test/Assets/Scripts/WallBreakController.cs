using UnityEngine;

public class WallBreakController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.Instance.hasDrill == true)
            {
                Destroy(gameObject);
            }

            //Write code here for drilling prompt
        }

    }
}
