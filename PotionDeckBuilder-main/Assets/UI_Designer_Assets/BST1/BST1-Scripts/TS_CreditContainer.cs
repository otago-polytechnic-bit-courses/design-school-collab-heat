using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TS_CreditContainer : MonoBehaviour
{
    private MMF_Player Credit_mmf_player;
    private List<MMF_SpringVector3> springFeedbacks;

    private void Awake()
    {
        if (TryGetComponent(out MMF_Player localFeedbackPlayer))
        {
            Credit_mmf_player = localFeedbackPlayer;
        }
        springFeedbacks = Credit_mmf_player.GetFeedbacksOfType<MMF_SpringVector3>();


    }
    public void CreditAnimationOn()
    {
        Debug.Log("CreditAnimationOn called");
        foreach(MMF_SpringVector3 feedback in springFeedbacks)
        {
            feedback.MoveToValue = Vector3.one * 5.5f;
        }
        StartCoroutine(CreditAnimationCoroutine());
    }

    public void CreditAnimationOff()
    {
        Debug.Log("CreditAnimationOff called");
        foreach (MMF_SpringVector3 feedback in springFeedbacks)
        {
            feedback.MoveToValue = Vector3.one * 0.1f;
        }
        
        
        Credit_mmf_player?.PlayFeedbacks();
    }

    public IEnumerator CreditAnimationCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Credit_mmf_player?.PlayFeedbacks();
    }
}
