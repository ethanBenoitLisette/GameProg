using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void IncreaseScore(int amount)  
    {
        score += amount;
        UpdateScoreText();
        Debug.Log("2");
    }

    public void IncreaseScoreFromEnemyExit()
    {
        int scoreIncreaseValue = 10;
        IncreaseScore(scoreIncreaseValue);
        Debug.Log("3");
    }
}
