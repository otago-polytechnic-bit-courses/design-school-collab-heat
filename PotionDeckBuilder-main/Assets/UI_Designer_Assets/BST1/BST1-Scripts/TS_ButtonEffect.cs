using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class TS_ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private MMF_Player feedbackPlayer;
    private MMF_SpringVector3 mmf_SpringVector3;
    [SerializeField] private MMF_Player feedbackIcon;
    private MMF_SpringVector3 mmf_SpringVector3Icon;
    [SerializeField] private Image inkImage;
    [SerializeField] private float buttonFeedbackScale = 1.1f;

    [SerializeField] private TS_MenuParallax menuParallax;

    [SerializeField] private Sprite hoverSprite;
    private Sprite localSprite;
    private Image localImage;

    private int siblingIndex;
    private void Awake()
    {
        if (hoverSprite != null)
        {
            localImage = GetComponent<Image>();
            localSprite = localImage.sprite;
        }

        

        if (TryGetComponent(out MMF_Player localFeedbackPlayer))
        {
            feedbackPlayer = localFeedbackPlayer;
        }
        mmf_SpringVector3 = feedbackPlayer.GetFeedbackOfType<MMF_SpringVector3>();
        if (feedbackIcon != null)
        {
            mmf_SpringVector3Icon = feedbackIcon.GetFeedbackOfType<MMF_SpringVector3>();
        }
        
        siblingIndex = transform.GetSiblingIndex();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        mmf_SpringVector3.MoveToValue = Vector3.one * buttonFeedbackScale;
        feedbackPlayer?.PlayFeedbacks();
        if (mmf_SpringVector3Icon != null)
        {
            mmf_SpringVector3Icon.MoveToValue = Vector3.one * 15f;
            feedbackIcon?.PlayFeedbacks();
        }
        if (inkImage != null)
        {
            inkImage.DOFade(1f, 0.2f);
        }
        if (menuParallax != null)
            menuParallax.MoveByIndex(siblingIndex);
        if(hoverSprite != null)
            localImage.sprite = hoverSprite;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mmf_SpringVector3.MoveToValue = Vector3.one * 1f;
        feedbackPlayer?.PlayFeedbacks();
        if (mmf_SpringVector3Icon != null)
        {
            mmf_SpringVector3Icon.MoveToValue = Vector3.one * 0.1f;
            feedbackIcon?.PlayFeedbacks();
        }
        if (inkImage != null)
        {
            inkImage.DOFade(0f, 0.2f);
        }
        if (menuParallax != null)
            menuParallax.ReturnToOrigin();
        if(hoverSprite != null)
            localImage.sprite = localSprite;
    }
}
