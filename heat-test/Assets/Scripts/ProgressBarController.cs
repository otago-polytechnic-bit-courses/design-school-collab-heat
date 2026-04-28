using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [Header("Progress Bar Settings")]
    [SerializeField] public float maxValue = 100f;
    [SerializeField] public float startValue;

    [SerializeField] Image progressBar;
    [SerializeField] GameObject limitReachedIndicator;

    public float CurrentValue { get; private set; }
    public event System.Action BarUpdate;
    public static ProgressBarController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        CurrentValue = startValue;
        UpdateBar();
    }

    private void Update()
    {
        if (limitReachedIndicator != null)
            limitReachedIndicator.SetActive(CurrentValue >= maxValue);
    }

    private void OnEnable()
    {
        BarUpdate += UpdateBar;
    }

    private void OnDisable()
    {
        BarUpdate -= UpdateBar;
    }

    // Add to the current value (e.g. elapsed time, XP gained, items collected)
    public void Increase(float amount)
    {
        CurrentValue += amount;
        BarUpdate?.Invoke();
    }

    // Subtract from the current value
    public void Decrease(float amount)
    {
        CurrentValue -= amount;
        CurrentValue = Mathf.Max(0, CurrentValue);
        BarUpdate?.Invoke();
    }

    // Directly set the current value (useful for timers driven by Time.deltaTime)
    public void SetValue(float value)
    {
        CurrentValue = Mathf.Clamp(value, 0, maxValue);
        BarUpdate?.Invoke();
    }

    // Reset back to the start value
    public void ResetBar()
    {
        CurrentValue = maxValue;
        BarUpdate?.Invoke();
    }

    private void UpdateBar()
    {
        progressBar.fillAmount = Mathf.Clamp01(CurrentValue / maxValue);
    }
}