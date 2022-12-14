using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public void SetSubjectID(int _SubjectID) // player choose subject
    {
        PlayerPrefs.SetInt("subjectID", _SubjectID);
    }

    public void SetQuizID(int _QuizID)
    {
        PlayerPrefs.SetInt("QuizID", _QuizID);
    }

    public void ChangeScene(string sceneTarget)
    {
        SceneManager.LoadScene(sceneTarget);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
