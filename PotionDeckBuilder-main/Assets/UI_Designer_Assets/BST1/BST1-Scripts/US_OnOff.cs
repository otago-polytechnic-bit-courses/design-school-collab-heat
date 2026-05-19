using DG.Tweening;
using MoreMountains.Tools;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class US_OnOff : MonoBehaviour
{
    private RectTransform panel;
    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpgradePanelUp()
    {
        panel.DOAnchorPosY(0f, 0.2f)
            .SetEase(Ease.OutCubic);
    }
    public void UpgradePanelOff()
    {
        panel.DOAnchorPosY(-1500, 0.2f)
            .SetEase(Ease.OutCubic);
    }
}
