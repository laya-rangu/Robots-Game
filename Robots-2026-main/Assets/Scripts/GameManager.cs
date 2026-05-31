using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    public int totalScore = 0;
    public int winThreshold = 70;

    [Header("Scenes")]
    public string winnerScene = "WinnerScene";
    public string loserScene = "LoserScene";

    [Header("Robot Consultation Tracking")]
    public bool[] robotsConsulted = new bool[4];

    [Header("Robot References")]
    public RobotInteraction[] robots;

    [Header("HUD Reference")]
    public HUDManager hudManager;

    public bool AllRobotsConsulted => robotsConsulted.All(r => r == true);

    // -------------------------------------------------------
    void Awake()
    {
        // Destroy any old lingering GameManager from previous session
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Force score to 0 immediately
        totalScore = 0;

        // Reset HUD immediately in Awake
        if (hudManager != null)
            hudManager.UpdateScore(0);

        Debug.Log("GameManager Awake. Score forced to 0.");
    }

    // -------------------------------------------------------
    void Start()
    {
        totalScore = 0;
        ResetConsultation();

        // Update HUD again in Start to be safe
        if (hudManager != null)
            hudManager.UpdateScore(0);

        Debug.Log("GameManager Start. Score: " + totalScore);
    }

    // -------------------------------------------------------
    public void MarkRobotConsulted(int index)
    {
        if (index < 0 || index >= robotsConsulted.Length) return;

        robotsConsulted[index] = true;

        Debug.Log("Robot " + index + " consulted. Total: "
            + robotsConsulted.Count(r => r == true) + "/4");

        QuestionManager.Instance.TryUnlockAnswers();
    }

    // -------------------------------------------------------
    public void ResetConsultation()
    {
        for (int i = 0; i < robotsConsulted.Length; i++)
            robotsConsulted[i] = false;

        if (robots != null)
        {
            foreach (var r in robots)
            {
                if (r != null)
                    r.ResetConsultedState();
            }
        }

        Debug.Log("Consultation reset.");
    }

    // -------------------------------------------------------
    public void AddScore(int pts)
    {
        totalScore += pts;

        Debug.Log("Score added: " + pts + " | Total: " + totalScore);

        if (hudManager != null)
            hudManager.UpdateScore(totalScore);
    }

    // -------------------------------------------------------
    public void EndGame()
    {
        bool won = totalScore >= winThreshold;

        Debug.Log("Game Over! Score: " + totalScore
            + " | Threshold: " + winThreshold
            + " | Won: " + won);

        StartCoroutine(LoadEndScene(won));
    }

    private IEnumerator LoadEndScene(bool won)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(won ? winnerScene : loserScene);
    }
}