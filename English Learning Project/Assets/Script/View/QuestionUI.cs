using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    public QuizController _QuizController;

    [Header("Question")]
    public TextMeshProUGUI textQuestion;

    [Header("Button Option")]
    public List<Button> buttonOption;

    [Header("panel reasult")]
    public GameObject panelResult;
    public TextMeshProUGUI textMessage;

    [Header("Score")]
    public TextMeshProUGUI trueResult;
    public TextMeshProUGUI falseResult;

    [Header("Toggle UI Componet")]
    public GameObject title;
    public GameObject displayQuestion;
    public GameObject scoreCorrect;
    public GameObject scoreIncorrect;

    private void Awake()
    {
        for (int i = 0; i < buttonOption.Count; i++)
        {
            Button localBtn = buttonOption[i];
            localBtn.onClick.AddListener(() => OnClickOption(localBtn));
        }
    }

    public void SendQuizResult(bool result)
    {
        panelResult.SetActive(true);

        if (result)
        {
            panelResult.GetComponent<Image>().color = Color.green;
            textMessage.text = "true";
        }
        else
        {
            panelResult.GetComponent<Image>().color = Color.red;
            textMessage.text = "false";
        }
    }

    public void OnClickOption(Button btn)
    {
        _QuizController.Answer(btn.name);
    }

    public void SetScoreResult(int _true, int _false)
    {
        trueResult.text = _true.ToString();
        falseResult.text = _false.ToString();
    }

    public void ToggleUI(bool result)
    {
        title.SetActive(result);
        displayQuestion.SetActive(result);
        scoreCorrect.SetActive(result);
        scoreIncorrect.SetActive(result);
    }
}
