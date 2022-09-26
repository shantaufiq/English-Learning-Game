using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCharComponents : MonoBehaviour
{
    public GameObject character;
    public TextMeshProUGUI DialogText;
    public GameObject DisplayDialog;

    public void ToggleIsOn(char l)
    {
        DialogText.text += l;
        character.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        DisplayDialog.SetActive(true);
    }
    public void ToggleIsOff()
    {
        DisplayDialog.SetActive(false);
        character.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
