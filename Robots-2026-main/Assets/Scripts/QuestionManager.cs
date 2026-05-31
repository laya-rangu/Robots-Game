using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    [Header("Questions")]
    public QuestionData[] questions;

    [Header("Tablet UI Reference")]
    public TabletUIController tabletUI;

    private int _currentIndex = 0;
    public QuestionData CurrentQuestion => questions[_currentIndex];

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartGame()
    {
        _currentIndex = 0;
        GameManager.Instance.ResetConsultation();
        tabletUI.ShowQuestionPanel(CurrentQuestion);
        tabletUI.LockAnswers();
    }

    public string GetRobotOpinion(int robotIndex)
    {
        return CurrentQuestion.GetRobotOpinion(robotIndex);
    }

    public void TryUnlockAnswers()
    {
        if (GameManager.Instance.AllRobotsConsulted)
            tabletUI.UnlockAnswers();
    }

    public void SubmitAnswer(int optionIndex)
    {
        var q = CurrentQuestion;
        int pts = q.options[optionIndex].points;
        GameManager.Instance.AddScore(pts);

        Debug.Log("Answer " + optionIndex + " selected. Points: " + pts);

        _currentIndex++;

        if (_currentIndex >= questions.Length)
        {
            // All questions done — end game
            Debug.Log("All questions done. Ending game.");
            GameManager.Instance.EndGame();
        }
        else
        {
            // Next question
            GameManager.Instance.ResetConsultation();
            tabletUI.ShowQuestionPanel(CurrentQuestion);
            tabletUI.LockAnswers();
        }
    }
}