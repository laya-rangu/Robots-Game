using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        // Destroy any old lingering HUDManager from previous session
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Force reset display to 0 immediately
        UpdateScore(0);

        Debug.Log("HUDManager Awake. Score display reset to 0.");
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("HUD updated to: " + score);
        }
        else
        {
            Debug.LogWarning("HUDManager: scoreText is not assigned!");
        }
    }
}