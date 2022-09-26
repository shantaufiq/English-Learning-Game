using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TypingStatus
{
    stopped, running, start
}

public class DialogController : MonoBehaviour
{
    public int _index;
    [Header("Dialog Components")]
    public List<MDialog> DialogStage;
    public List<AudioSource> Audios = new List<AudioSource>();
    public TypingStatus typingstatus;
    public float typingSpeed;
    [SerializeField] private TextMeshProUGUI _TextMeshComponent1;
    [SerializeField] private TextMeshProUGUI _TextMeshComponent2;

    [Header("UI Object")]
    public GameObject DialogComponents;
    public GameObject DisplayDialog1;
    public GameObject DisplayDialog2;
    public GameObject DisplayChar1;
    public GameObject DisplayChar2;

    private void Awake()
    {
        typingstatus = TypingStatus.stopped;
        _index = 0;
    }

    private void Start() => SetAudiosClip();

    private void Update()
    {
        if (typingstatus == TypingStatus.start)
        {
            for (int i = 0; i < DialogStage.Count; i++)
            {
                if (i == _index)
                {
                    StartCoroutine(TypingEffect(i));

                }
            }
        }
    }

    public void SetAudiosClip()
    {
        for (int i = 0; i < DialogStage.Count; i++)
        {
            Audios.Add(gameObject.AddComponent<AudioSource>());
            Audios[i].clip = DialogStage[i].AudioClip;
        }
    }

    public IEnumerator TypingEffect(int index)
    {
        typingstatus = TypingStatus.running;
        _TextMeshComponent1.text = "";
        _TextMeshComponent2.text = "";

        Audios[_index].Play();

        foreach (char l in DialogStage[_index].Dialog.ToCharArray())
        {
            ToggleOnOffDialog(DialogStage[_index].CharacterID, l);

            yield return new WaitForSeconds(typingSpeed);
        }
        typingstatus = TypingStatus.stopped;
    }

    public void ToggleOnOffDialog(int charid, char l)
    {
        switch (charid)
        {
            case 0:
                _TextMeshComponent1.text += l;
                DisplayChar1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                DisplayChar2.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 1:
                _TextMeshComponent2.text += l;
                DisplayChar1.transform.localScale = new Vector3(1f, 1f, 1f);
                DisplayChar2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
        }

        // temporary jika 2 character
        var stat1 = charid == 0 ? true : false;
        var stat2 = charid == 1 ? true : false;

        DisplayDialog1.SetActive(stat1);
        DisplayDialog2.SetActive(stat2);
    }

    public void NextDialog()
    {
        if (_index == DialogStage.Count - 1 || typingstatus == TypingStatus.running) return;
        _index = _index < DialogStage.Count - 1 ? _index + 1 : DialogStage.Count - 1;
        typingstatus = TypingStatus.start;
    }

    public void PreviousDialog()
    {
        if (_index == 0 || typingstatus == TypingStatus.running) return;
        _index = _index < 0 ? _index - 1 : 0;
        typingstatus = TypingStatus.start;
    }

    public void StartDialog()
    {
        DialogComponents.SetActive(true);
        typingstatus = TypingStatus.start;
    }
}
