using DG.Tweening;
using MoreMountains.Feedbacks;
using MoreMountains.Feel;
using UnityEngine;

public class TS_CreditMechanics : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private RectTransform creditPage;
    private TS_CreditContainer creditContainer;
    private MMSpringPosition springPosition;
    
    private MMF_SpringVector3 mmf_SpringVector3;

    private void Awake()
    {
        springPosition = panel.GetComponent<MMSpringPosition>();
        creditContainer = creditPage.GetComponent<TS_CreditContainer>();
    }

    public void PanelDown()
    {
        // Move panel
        panel.DOAnchorPosY(-900f, 0.2f)
            .SetEase(Ease.OutCubic);

        creditPage.DOAnchorPosY(0f, 0.2f)
            .SetEase(Ease.OutCubic);
        creditContainer.CreditAnimationOn();
    }

    public void PanelUp()
    {
        creditContainer.CreditAnimationOff();

        creditPage.DOAnchorPosY(-1500f, 0.2f)
            .SetEase(Ease.OutCubic);
        // Move panel
        panel.DOAnchorPosY(200f, 0.2f)
            .SetEase(Ease.OutCubic);
    }
}
