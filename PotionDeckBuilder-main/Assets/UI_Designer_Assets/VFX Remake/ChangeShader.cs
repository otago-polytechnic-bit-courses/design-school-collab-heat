using UnityEngine;
using UnityEngine.UI;

public class ChangeShader : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    private Material mat;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        mat = image.material = new Material(image.material);
    }

    public void changePropertyOfShader()
    {
        mat.SetFloat("_HitEffectBlend", 1);
    }
}
