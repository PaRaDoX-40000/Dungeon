using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void Init(string str)
    {
        text.text = str;
    }
}
