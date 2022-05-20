using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PictureWithText : MonoBehaviour
{
    public Image image;
    public TMP_Text text;
    

    public void Init(Sprite sprite, string text)
    {
        image.sprite = sprite;
        this.text.text = text;
        gameObject.SetActive(true);
    }
    public void SetColorText(Color color)
    {

        text.color = color;


    }
}
