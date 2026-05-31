using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletUIController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;
    public GameObject questionPanel;

    [Header("Question UI")]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI lockText;

    [Header("Answer Buttons")]
    public Button[] answerButtons = new Button[4];
    public TextMeshProUGUI[] answerTexts = new TextMeshProUGUI[4];

    void Start()
    {
        startPanel.SetActive(true);
        questionPanel.SetActive(false);
    }

    public void OnStartClicked()
    {
        startPanel.SetActive(false);
        questionPanel.SetActive(true);
        QuestionManager.Instance.StartGame();
    }

    public void ShowQuestionPanel(QuestionData q)
    {
        questionPanel.SetActive(true);
        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerTexts[i].text = q.options[i].optionText;
            answerButtons[i].interactable = false;
        }

        lockText.gameObject.SetActive(true);
    }

    public void UnlockAnswers()
    {
        foreach (var btn in answerButtons)
            btn.interactable = true;
        lockText.gameObject.SetActive(false);
    }

    public void LockAnswers()
    {
        foreach (var btn in answerButtons)
            btn.interactable = false;
        lockText.gameObject.SetActive(true);
    }

    public void OnAnswer0() => QuestionManager.Instance.SubmitAnswer(0);
    public void OnAnswer1() => QuestionManager.Instance.SubmitAnswer(1);
    public void OnAnswer2() => QuestionManager.Instance.SubmitAnswer(2);
    public void OnAnswer3() => QuestionManager.Instance.SubmitAnswer(3);
}