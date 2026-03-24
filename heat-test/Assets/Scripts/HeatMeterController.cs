using UnityEngine;

public class HeatMeterController : MonoBehaviour
{
   [SerializeField]ProgressBarController progress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress.Decrease(Time.deltaTime);
        Debug.Log($"Time:{progress.CurrentValue}");
    }
}
