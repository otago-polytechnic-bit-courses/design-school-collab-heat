using UnityEngine;

public class Bop : MonoBehaviour
{
    [Header("Bop Settings")]
    public Vector3 bopAxis = Vector3.up; // direction of bop
    public float amplitude = 10f;        // distance moved
    public float frequency = 2f;         // speed of bop

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + bopAxis * offset;
    }
}
