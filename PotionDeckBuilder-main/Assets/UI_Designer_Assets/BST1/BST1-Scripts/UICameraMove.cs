using UnityEngine;
using UnityEngine.EventSystems;
using MoreMountains.Feedbacks;

public class UICameraMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Target to Move")]
    public Transform target; // CameraTarget

    [Header("Feel Feedback")]
    public MMF_Player feedback;

    private MMF_Position positionFeedback;

    private Vector3 initialPosition;

    [Header("Settings")]
    public float moveAmount = 1f;

    void Start()
    {
        // Store initial position
        initialPosition = target.position;

        // Get the MMF_Position feedback
        positionFeedback = feedback.GetFeedbackOfType<MMF_Position>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (feedback.IsPlaying)
            feedback.StopFeedbacks();

        // Move UP by 1 (relative to start)
        positionFeedback.InitialPosition = target.position;
        positionFeedback.DestinationPosition = initialPosition + Vector3.up * moveAmount;

        feedback.Initialization();
        feedback.PlayFeedbacks();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (feedback.IsPlaying)
            feedback.StopFeedbacks();

        // Move BACK to original position
        positionFeedback.InitialPosition = target.position;
        positionFeedback.DestinationPosition = initialPosition;

        feedback.Initialization();
        feedback.PlayFeedbacks();
    }
}
