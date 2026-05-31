using UnityEngine;
using TMPro;
 
public class ScoreDisplay : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;
    
    [Header("Settings")]
    public int winThreshold = 100;
    
    private int currentScore = 0;
 
    void Start()
    {
        if (GameManager.Instance != null)
        {
            currentScore = GameManager.Instance.totalScore;
            UpdateScoreDisplay();
        }
    }
 
    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (currentScore != GameManager.Instance.totalScore)
            {
                currentScore = GameManager.Instance.totalScore;
                UpdateScoreDisplay();
            }
        }
    }
 
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore + "/" + winThreshold;
        }
    }
}
