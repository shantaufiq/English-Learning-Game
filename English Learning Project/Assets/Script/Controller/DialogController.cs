using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TypingStatus
{
    stopped, running, finish
}

public class DialogController : MonoBehaviour
{
    public static DialogController instance;
    public int _index;
    public TypingStatus typingstatus;
    public List<MDialog> DialogStage;
    public float typingSpeed;
    [SerializeField] private TextMeshProUGUI _TextMeshComponent1;
    [SerializeField] private TextMeshProUGUI _TextMeshComponent2;

    private void Awake()
    {
        instance = this;
        typingstatus = TypingStatus.stopped;
    }

    private void Update()
    {
        if (typingstatus == TypingStatus.running) Debug.Log("is running");
        if (typingstatus == TypingStatus.stopped)
        {
            for (int i = 0; i < DialogStage.Count; i++)
            {
                if (i == _index)
                    StartCoroutine(TypingEffect(i));
            }
        }
    }

    public IEnumerator TypingEffect(int index)
    {
        typingstatus = TypingStatus.running;
        _TextMeshComponent1.text = "";
        _TextMeshComponent2.text = "";
        foreach (char l in DialogStage[_index].Dialog.ToCharArray())
        {
            _TextMeshComponent1.text += l;
            _TextMeshComponent2.text += l;
            yield return new WaitForSeconds(typingSpeed);
        }
        typingstatus = TypingStatus.finish;
    }

    public void NextDialog()
    {
        if (_index == DialogStage.Count - 1) return;
        _index = _index < DialogStage.Count - 1 ? _index + 1 : DialogStage.Count - 1;
        typingstatus = TypingStatus.stopped;
    }
    public void PreviousDialog()
    {
        if (_index == 0) return;
        _index = _index < 0 ? _index - 1 : 0;
        typingstatus = TypingStatus.stopped;
    }
}
