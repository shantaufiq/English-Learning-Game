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

    [Header("panel reasult True or False")]
    public GameObject panelResult;
    public TextMeshProUGUI textMessage;
    public Sprite trueImage;
    public Sprite falseImage;

    [Header("Score Bar")]
    public TextMeshProUGUI trueResult;
    public TextMeshProUGUI falseResult;

    [Header("Toggle UI Componet")]
    public GameObject title;
    public GameObject displayQuestion;
    public GameObject scoreCorrect;
    public GameObject scoreIncorrect;

    [Header("Pop-up Score Result")]
    public GameObject scoreResult;
    public TextMeshProUGUI correctScore;
    public TextMeshProUGUI incorrectScore;

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
            // panelResult.GetComponent<Image>().color = Color.green;
            panelResult.GetComponent<Image>().sprite = trueImage;
            textMessage.text = "true";
        }
        else
        {
            // panelResult.GetComponent<Image>().color = Color.red;
            panelResult.GetComponent<Image>().sprite = falseImage;
            textMessage.text = "false";
        }
    }

    public void OnClickOption(Button btn)
    {
        _QuizController.Answer(btn.name);
    }

    public void OnClickResetGame()
    {
        _QuizController.ResetGame();
        ToggleUI(true);
        trueResult.text = "0";
        falseResult.text = "0";
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

    public void DisplayGameFinish(int correct, int incorrect)
    {
        scoreResult.SetActive(true);
        correctScore.text = correct.ToString();
        incorrectScore.text = incorrect.ToString();
    }
}
