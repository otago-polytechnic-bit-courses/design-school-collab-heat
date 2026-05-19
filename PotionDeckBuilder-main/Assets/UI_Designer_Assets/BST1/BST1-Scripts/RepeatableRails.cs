using UnityEngine;

public class RepeatableRails : MonoBehaviour
{
    [Header("Rails (assign your 2 UI images here)")]
    public RectTransform railA;
    public RectTransform railB;

    [Header("Positions (empty UI objects)")]
    public RectTransform destinationPoint; // when rail reaches this → reset
    public RectTransform resetPoint;       // where it gets moved to

    [Header("Movement")]
    public float speed = 200f; // pixels per second

    void Update()
    {
        MoveRail(railA);
        MoveRail(railB);
    }

    void MoveRail(RectTransform rail)
    {
        // Move to the right
        rail.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        // Check if it passed destination point
        if (rail.anchoredPosition.x >= destinationPoint.anchoredPosition.x)
        {
            // Move it back to reset point
            rail.anchoredPosition = new Vector2(
                resetPoint.anchoredPosition.x,
                rail.anchoredPosition.y // keep same Y
            );
        }
    }
}