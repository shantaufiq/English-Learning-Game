using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    int _index;
    public List<QuizSubject> QuestionsSubject;

    private void Awake() => _index = PlayerPrefs.GetInt("QuizID");

    public List<MQuestion> GetData() => QuestionsSubject[_index].Questions;
}
