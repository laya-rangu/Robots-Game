using UnityEngine;
using TMPro;

public class RobotInteraction : MonoBehaviour
{
    [Header("Robot Identity")]
    [Tooltip("0=PIPER, 1=SAM, 2=HELO, 3=GIDE")]
    public int robotIndex;
    public string robotName;

    [Header("Opinion Display")]
    public GameObject opinionCanvas;
    public TextMeshProUGUI opinionText;
    public float displayDuration = 5f;

    private bool _consulted = false;

    void Start()
    {
        if (opinionCanvas != null)
            opinionCanvas.SetActive(false);
    }

    // -------------------------------------------------------
    // Wire this to the Button's OnClick in Inspector
    public void OnNameTagClicked()
    {
        Debug.Log(robotName + " name tag clicked.");

        // Show opinion for current question
        if (QuestionManager.Instance != null)
        {
            string opinion = QuestionManager.Instance.GetRobotOpinion(robotIndex);
            ShowOpinion(opinion);
        }
        else
        {
            Debug.LogWarning("QuestionManager not found!");
        }

        // Mark consulted once per question
        if (!_consulted)
        {
            _consulted = true;
            if (GameManager.Instance != null)
                GameManager.Instance.MarkRobotConsulted(robotIndex);
        }
    }

    // -------------------------------------------------------
    void ShowOpinion(string text)
    {
        if (opinionCanvas != null && opinionText != null)
        {
            opinionText.text = robotName + ":\n" + text;
            opinionCanvas.SetActive(true);

            CancelInvoke(nameof(HideOpinion));
            Invoke(nameof(HideOpinion), displayDuration);
        }
        else
        {
            Debug.LogWarning(robotName + ": opinionCanvas or opinionText not assigned!");
        }
    }

    void HideOpinion()
    {
        if (opinionCanvas != null)
            opinionCanvas.SetActive(false);
    }

    // -------------------------------------------------------
    // Called by GameManager.ResetConsultation() each new question
    public void ResetConsultedState()
    {
        _consulted = false;
        if (opinionCanvas != null)
            opinionCanvas.SetActive(false);
    }
}