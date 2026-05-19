using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Direction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform targetUI;  // The UI element (anchor)
    public Camera uiCamera;         // Only needed in Screen Space Camera mode
    [SerializeField] private MMF_Player cameraFeedback;
    [SerializeField] private float strength = 1f;

    /// <summary>
    /// Returns a normalized direction vector from screen center to this UI object.
    /// </summary>
    public Vector2 GetDirection()
    {
        // 1. Get screen center
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        // 2. Convert UI element position → screen space
        Vector2 uiScreenPos;

        if (uiCamera != null)
        {
            uiScreenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, targetUI.position);
        }
        else
        {
            // Screen Space Overlay (camera not needed)
            uiScreenPos = (Vector2)targetUI.position;
        }

        // 3. Direction from center → UI element
        Vector2 direction = uiScreenPos - screenCenter;

        // 4. Normalize so center = (0,0), right = (1,0), up = (0,1), etc.
        
        return direction.normalized;
    }

    private MMF_Position mMF_Position;
    private Vector2 dir;
    private void Start()
    {
        mMF_Position = cameraFeedback.GetFeedbackOfType<MMF_Position>();

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Entered UI Element");
        if (cameraFeedback.IsPlaying)
        {
            cameraFeedback.StopFeedbacks();
        }

        dir = GetDirection();

        Vector3 currentPos = uiCamera.transform.position;
        mMF_Position.InitialPosition = currentPos;
        mMF_Position.DestinationPosition = new Vector3(dir.x * strength, dir.y * strength, -10);

        cameraFeedback.Initialization();
        cameraFeedback.PlayFeedbacks();
    }
        
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exited UI Element");
        if (cameraFeedback.IsPlaying)
        {
            cameraFeedback.StopFeedbacks();
        }

        mMF_Position.InitialPosition = uiCamera.transform.position;
        mMF_Position.DestinationPosition = new Vector3(0, 0, -10); 



        //dir = GetDirection();

        //mMF_Position.DestinationPosition = new Vector3(-dir.x * strength, -dir.y * strength, 0);




        cameraFeedback.Initialization();
        cameraFeedback.PlayFeedbacks();


    }

    public void ShowDirection()
    {
        Vector2 dir = GetDirection();
        Debug.Log("Direction = " + dir);
    }
}
