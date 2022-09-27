using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizController : MonoBehaviour
{
    [SerializeField] int _index;
    public List<MQuestion> _Questions;
    public QuizManager _QuizManager;
    public QuestionUI _QuestionUI;

    [SerializeField] private int correctPoint;
    [SerializeField] private int incorrectPoint;

    private void Start()
    {
        _Questions = _QuizManager.GetData();
    }
    private void Update()
    {
        SetQuestion();

        if (correctPoint + incorrectPoint == _Questions.Count) Debug.Log("selesai");
    }
    public void SetQuestion()
    {
        _QuestionUI.textQuestion.text = _Questions[_index].Question;

        for (int i = 0; i < _QuestionUI.buttonOption.Count; i++)
        {
            _QuestionUI.buttonOption[i].GetComponentInChildren<TextMeshProUGUI>().text = _Questions[_index].Option[i];
            _QuestionUI.buttonOption[i].name = _Questions[_index].Option[i];
        }
    }

    public void Answer(string answerd)
    {
        if (answerd == _Questions[_index].CorrectAnswer)
        {
            // yess
            _QuestionUI.SendQuizResult(true);

            correctPoint += 1;
            _index = _index < _Questions.Count - 1 ? _index + 1 : _Questions.Count - 1;
        }
        else
        {
            // no
            _QuestionUI.SendQuizResult(false);

            incorrectPoint += 1;
            _index = _index < _Questions.Count - 1 ? _index + 1 : _Questions.Count - 1;
        }

        _QuestionUI.ToggleUI(false);
        _QuestionUI.SetScoreResult(correctPoint, incorrectPoint);
    }
}
