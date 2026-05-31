using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Game/QuestionData")]
public class QuestionData : ScriptableObject
{
    [TextArea] public string questionText;
    public AnswerOption[] options = new AnswerOption[4];
    public int correctAnswerIndex; // the objectively correct answer

    // One opinion line per robot: 0=PIPER, 1=SAM, 2=HELO, 3=GIDE
    [TextArea] public string piperOpinion;
    [TextArea] public string samOpinion;
    [TextArea] public string heloOpinion;
    [TextArea] public string gideOpinion;

    public string GetRobotOpinion(int robotIndex)
    {
        switch (robotIndex)
        {
            case 0: return piperOpinion;
            case 1: return samOpinion;
            case 2: return heloOpinion;
            case 3: return gideOpinion;
            default: return "";
        }
    }
}

[System.Serializable]
public class AnswerOption
{
    public string optionText;
    public int points;
}