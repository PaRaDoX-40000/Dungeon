using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text someText;


    //public TMP_Text CharacterName => characterName;
    //public Image Icon  => icon; 
    //public TMP_Text SomeText  => someText;

    public void Init(string characterName, Sprite icon, string someText)
    {
        this.characterName.text = characterName;
        this.icon.sprite = icon;
        this.someText.text = someText;
    }
}
