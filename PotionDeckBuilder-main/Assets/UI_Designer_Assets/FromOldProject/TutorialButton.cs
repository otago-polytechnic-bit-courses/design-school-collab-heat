using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] private GameObject tutorialTexts;
    [SerializeField] private TMP_Text buttonMark;
    public void TutorialButtonOnClick()
    {
        if (!tutorialTexts.activeSelf)
        {
            tutorialTexts.SetActive(true);
            buttonMark.text = "x";
        }
        else
        {
            tutorialTexts.SetActive(false);
            buttonMark.text = "?";
        }
        

        
    }

    public void LoadNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
