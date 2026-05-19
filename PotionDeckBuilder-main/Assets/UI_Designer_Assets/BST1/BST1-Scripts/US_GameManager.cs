using DG.Tweening;
using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class US_GameManager : MonoBehaviour
{
    [SerializeField] private RectTransform resourceButton;
    [SerializeField] private RectTransform toolButton;
    private bool resourceIsOpened = false;
    private bool toolIsOpened = false;

    [SerializeField] private RectTransform[] trainObjectsA;
    [SerializeField] private RectTransform[] trainObjectsB;

    private RectTransform[] trainObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MoveResourceButton()
    {
        if (toolIsOpened)
        {
            MoveToolButton();
        }
        trainObjects = trainObjectsA;
        resourceIsOpened = !resourceIsOpened;
        float targetYA = resourceIsOpened ? -1600f : -700f;

        resourceButton.DOAnchorPosX(targetYA, 0.2f)
            .SetEase(Ease.OutCubic);
        ToggleTrainEffect();
    }
    public void MoveToolButton()
    {
        if (resourceIsOpened) {
            MoveResourceButton();
        }
        trainObjects = trainObjectsB;
        toolIsOpened = !toolIsOpened;
        float targetYB = toolIsOpened ? -800f : -125f;

        toolButton.DOAnchorPosX(targetYB, 0.2f)
            .SetEase(Ease.OutCubic);
        ToggleTrainEffect();
    }

    private bool trainEffectActive = false;

    private Coroutine trainCoroutine;

    public void ToggleTrainEffect()
    {
        trainEffectActive = !trainEffectActive;

        if (trainEffectActive)
        {
            trainCoroutine = StartCoroutine(TrainEffectCoroutine());
        }
        else
        {
            StopCoroutine(trainCoroutine);

            StopAllTrainTweens();
        }
    }

    private IEnumerator TrainEffectCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < trainObjects.Length; i++)
            {
                RectTransform rect = trainObjects[i];

                float randomHeight = Random.Range(3f, 8f);

                float randomDuration = Random.Range(0.03f, 0.08f);

                rect.DOKill();

                Tween tween = rect.DOAnchorPosY(
                    rect.anchoredPosition.y + randomHeight,
                    randomDuration
                )
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.OutQuad);

                // Wait until this bump finishes
                //yield return tween.WaitForCompletion();

                // Small delay between objects
                yield return new WaitForSeconds(
                    Random.Range(0.03f, 0.08f)
                );
            }
            // RANDOM delay BEFORE next loop starts
            yield return new WaitForSeconds(
                Random.Range(0.5f, 2f)
            );
        }
    }

    private void StopAllTrainTweens()
    {
        foreach (RectTransform rect in trainObjects)
        {
            rect.DOKill();

            rect.DOAnchorPosY(
                0f,
                0.15f
            );
        }
    }

}
