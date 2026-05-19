using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine.EventSystems;
using MoreMountains.Feel;

public class Button_Spring : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MMF_Player feedbackPlayer;
    [SerializeField] private MMF_Player feedbackPlayer02;

    private MMSpringScale springScale;
    private void Awake()
    {
        if (TryGetComponent(out MMSpringScale localSpringScale))
        {
            springScale = localSpringScale;
        }
    }
    private void Start()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (MMF_Feedback feedback in feedbackPlayer.FeedbacksList)
        {
            if (feedback.MMChannelDefinition == springScale.MMChannelDefinition)
            {
                feedback.Active = true;
                Debug.Log(springScale.MMChannelDefinition.ToString());
            }
            else
            {
                feedback.Active = false;
            }
        }

        feedbackPlayer?.PlayFeedbacks();
     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (MMF_Feedback feedback in feedbackPlayer02.FeedbacksList)
        {
            if (feedback.MMChannelDefinition == springScale.MMChannelDefinition)
            {
                feedback.Active = true;
            }
            else
            {
                feedback.Active = false;
            }
        }

        feedbackPlayer02?.PlayFeedbacks();
    }
}
