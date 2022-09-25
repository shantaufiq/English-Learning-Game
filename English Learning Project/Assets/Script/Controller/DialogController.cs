using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TypingStatus
{
    stopped, running, blocked
}

public class DialogController : MonoBehaviour
{
    int _index;
    public TypingStatus typingstatus;
    public List<MDialog> Dialog_Introduce;
    public float typingSpeed;
    [SerializeField] private TextMeshProUGUI _TextMeshComponent1;
    [SerializeField] private TextMeshProUGUI _TextMeshComponent2;

    private void Start()
    {

    }

    private void Update()
    {
        if (typingstatus == TypingStatus.running) Debug.Log("is running");
        if (typingstatus == TypingStatus.stopped && _index < Dialog_Introduce.Count)
            StartCoroutine(TypingEffect());
    }

    public IEnumerator TypingEffect()
    {
        typingstatus = TypingStatus.running;
        _TextMeshComponent1.text = "";
        _TextMeshComponent2.text = "";
        foreach (char l in Dialog_Introduce[_index].Dialog.ToCharArray())
        {
            _TextMeshComponent1.text += l;
            _TextMeshComponent2.text += l;
            yield return new WaitForSeconds(typingSpeed);
        }

        _index++;
        typingstatus = TypingStatus.stopped;
    }
}
