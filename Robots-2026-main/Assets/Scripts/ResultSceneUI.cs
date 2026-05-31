using UnityEngine;
using TMPro;

public class ResultSceneUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI messageText;

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager not found!");
            return;
        }

        int score = GameManager.Instance.totalScore;
        bool won = score >= GameManager.Instance.winThreshold;

        if (titleText != null)
            titleText.text = won ? "YOU WIN!" : "YOU LOSE!";

        if (scoreText != null)
            scoreText.text = "Final Score: " + score;

        if (messageText != null)
        {
            messageText.text = won
                ? "You saw through the lies.\nYou think for yourself."
                : "The robots fooled you.\nYou followed the herd.";
        }
    }

    public void OnPlayAgain()
    {
        if (GameManager.Instance != null)
            Destroy(GameManager.Instance.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}