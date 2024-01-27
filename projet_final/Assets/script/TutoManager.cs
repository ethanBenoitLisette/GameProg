using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public Canvas tutorialCanvas;
    public TextMeshProUGUI tutorialText;
    private bool isGamePaused = true;


    void Start()
    {
        ShowTutorial();
    }

    void Update()
    {
        if (isGamePaused && Input.GetKeyDown(KeyCode.Space))
        {
            ResumeGame();
        }
    }
    void ShowTutorial()
    {
        if (tutorialCanvas != null && tutorialText != null)
        {
            tutorialCanvas.gameObject.SetActive(true);
            tutorialText.text = "Bienvenue ! Appuyez sur [ESPACE] pour sauter.";

            Time.timeScale = 0f;
        }
    }

    void HideTutorial()
    {
        if (tutorialCanvas != null)
        {
            tutorialCanvas.gameObject.SetActive(false);

            Time.timeScale = 1f;

            isGamePaused = false;
        }
    }
    void ResumeGame()
    {
        
        HideTutorial();
    }

}
