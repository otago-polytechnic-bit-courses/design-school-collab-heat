using DG.Tweening;
using UnityEngine;

public class TS_MenuParallax : MonoBehaviour
{
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxIntensity = 0.5f;

    private Vector3 originalPosition;

    private Tween currentTween;

    private void Awake()
    {
        originalPosition = background.localPosition;
    }

    public void MoveByIndex(int index)
    {
        currentTween?.Kill();

        float yOffset = 0f;

        switch (index)
        {
            case 0:
                yOffset = 2f;
                break;

            case 1:
                yOffset = 1f;
                break;

            case 2:
                yOffset = 0f;
                break;

            case 3:
                yOffset = -1f;
                break;

            case 4:
                yOffset = -2f;
                break;
        }

        Vector3 targetPosition =
            originalPosition + new Vector3(0, yOffset*parallaxIntensity, 0);

        currentTween = background.DOLocalMove(
            targetPosition,
            0.35f
        )
        .SetEase(Ease.OutCubic);
    }

    public void ReturnToOrigin()
    {
        currentTween?.Kill();

        currentTween = background.DOLocalMove(
            originalPosition,
            0.35f
        )
        .SetEase(Ease.OutCubic);
    }
}