using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleHeroPanel : MonoBehaviour
{
   [SerializeField] private Image icon;
   [SerializeField] private TMP_Text nameText;
   [SerializeField] private Image deathImage;

    public void Init(Sprite icon,string name,bool dead)
    {
        this.icon.sprite = icon;
        nameText.text = name;
        deathImage.gameObject.SetActive(!dead);
        gameObject.SetActive(true);
    }
}
