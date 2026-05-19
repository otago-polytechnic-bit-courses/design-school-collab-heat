using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine.EventSystems;
using MoreMountains.Feel;

public class Testing : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MMF_Player feedbackPlayer;
    [SerializeField] private MMF_Player feedbackPlayer02;
    

    //private MMSpringScale springScale;

    private void Awake()
    {
        //springScale = GetComponent<MMSpringScale>();
    }
    /*private float lastTriggerTime;
    private float cooldown = 0.1f; // Have to be larger than the feedback duration
    private bool firstTrigger = false;
    private bool leverActivated = false;

    [SerializeField] private float hoverDamping = 0.3f; // smoother bounce
    [SerializeField] private float exitDamping = 0.8f;  // faster settle
    [SerializeField] private MMSpringScale springScale;*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        //foreach (MMF_Feedback feedback in feedbackPlayer.FeedbacksList)
        //{
        //    if (feedback.MMChannelDefinition == springScale.MMChannelDefinition)
        //    {
        //        feedback.Active = true;
        //    }
        //    else
        //    {
        //        feedback.Active = false;
        //    }
        //}

        //springScale.MMChannelDefinition

        feedbackPlayer?.PlayFeedbacks();




        //InvokeRepeating(nameof(DoBump), 1f, 1f);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //foreach (MMF_Feedback feedback in feedbackPlayer02.FeedbacksList)
        //{
        //    if (feedback.MMChannelDefinition == springScale.MMChannelDefinition)
        //    {
        //        feedback.Active = true;
        //    }
        //    else
        //    {
        //        feedback.Active = false;
        //    }
        //}

        feedbackPlayer02?.PlayFeedbacks();


        //CancelInvoke(nameof(DoBump));
    }
}
