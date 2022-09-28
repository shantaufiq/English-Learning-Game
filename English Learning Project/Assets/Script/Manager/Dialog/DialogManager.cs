using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogManager : MonoBehaviour
{
    int _index;
    public List<DialogSubject> _Dialogs;
    public DialogController _DialogController;
    private void Awake() =>
        _index = PlayerPrefs.GetInt("subjectID");

    private void Start() =>
        SetDialogsOnStage();

    public void SetDialogsOnStage()
    {
        foreach (MDialog dialog in _Dialogs[_index]._DialogSubject)
        {
            _DialogController.DialogStage.Add(dialog);
        }
    }
}
