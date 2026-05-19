using DG.Tweening;
using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UG_GameManager : MonoBehaviour
{
    [SerializeField] private RectTransform targetUI;
    [SerializeField] private MMF_Player screenshotMove;
    [SerializeField] private Image screenshotImage;
    private MMF_SpringVector3 springVector3;
    private MMF_Scale springScale;

    private bool isOpened = false;

    // Closed position
    [SerializeField] private Vector3 closedPosition = new Vector3(700f, -125f, -2500f);

    // Open position
    [SerializeField] private Vector3 openPosition = new Vector3(0f, -125f, 1f);

    [SerializeField] private Vector3 screenshotMoveValue = new Vector3(-600f, -80f, 0f);
    private void Awake()
    {
        if (screenshotMove != null)
        {
            springVector3 =
                screenshotMove.GetFeedbackOfType<MMF_SpringVector3>();
            springScale =
                screenshotMove.GetFeedbackOfType<MMF_Scale>();
        }

        Color color = screenshotImage.color;
        color.a = 0f;
        screenshotImage.color = color;
    }
    public void ToggleUIPosition()
    {
        StartCoroutine(ToggleUICoroutine());
    }
    private IEnumerator ToggleUICoroutine()
    {
        isOpened = !isOpened;

        // WAIT for screenshot to finish
        if (isOpened)
        yield return StartCoroutine(CoroutineScreenshot());

        Vector3 targetPosition =
            isOpened ? openPosition : closedPosition;

        Tween moveTween = targetUI.DOLocalMove(
            targetPosition,
            0.3f
        )
        .SetEase(Ease.OutCubic);

        if(isOpened)
        yield return moveTween.WaitForCompletion();

        if (springVector3 != null && springScale != null)
        {
            if (isOpened)
            {
                screenshotImage.DOFade(1f, 0.25f);

                springVector3.MoveToValue =
                    screenshotMoveValue;

                springScale.DestinationScale =
                    Vector3.one * 1.65f;

                screenshotMove.PlayFeedbacks();
            }
            else
            {
                screenshotImage.DOFade(0f, 0.1f);
                springVector3.MoveToValue = Vector3.zero;

                springScale.DestinationScale =
                    Vector3.one;

                screenshotMove.PlayFeedbacks();

                
            }
        }
    }

    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // Capture full screen size
        int width = Screen.width;
        int height = Screen.height;

        // Create texture
        Texture2D screenshotTexture = new Texture2D(
            width,
            height,
            TextureFormat.ARGB32,
            false
        );

        // Capture entire screen
        Rect rect = new Rect(0, 0, width, height);

        screenshotTexture.ReadPixels(rect, 0, 0);
        screenshotTexture.Apply();

        // Convert to sprite
        Sprite sprite = Sprite.Create(
            screenshotTexture,
            new Rect(0, 0, width, height),
            new Vector2(0.5f, 0.5f)
        );

        // Assign to UI Image
        screenshotImage.sprite = sprite;

        Debug.Log("Captured full screenshot and assigned to UI Image.");

        //// Convert to PNG
        //byte[] byteArray = screenshotTexture.EncodeToPNG();

        //// Save file
        //string path = Application.dataPath + "/Screenshots/CameraScreenshot.png";

        //System.IO.File.WriteAllBytes(path, byteArray);

        //Debug.Log("Saved screenshot to: " + path);

    }
}
