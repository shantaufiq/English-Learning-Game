using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogManager : MonoBehaviour
{
    int _index;
    public List<DialogSection> _Dialogs;
    private void Awake()
    {
        _index = PlayerPrefs.GetInt("subjectID");
    }
    private void Start()
    {
        SetDialogsOnStage();
    }
    public void SetDialogsOnStage()
    {
        foreach (MDialog dialog in _Dialogs[_index]._Dialog)
        {
            DialogController.instance.DialogStage.Add(dialog);
        }
    }
}
