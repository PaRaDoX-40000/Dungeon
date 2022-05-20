using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EquipableDetailedPanel : MonoBehaviour
{

    [SerializeField] private Image icon;
    [SerializeField] private Image buttonImage;
    [SerializeField] private TMP_Text buttonText; 
    [SerializeField] private TextPanel[] StatsText;
    [SerializeField] private Color equipColor;
    [SerializeField] private Color disequipColor;


    public void ShowDetailedEquipable(Equipable equipable)
    {
        icon.sprite = equipable.Icon;
        SetButton(equipable.Equipped);
        foreach(TextPanel textPanel in StatsText)
        {
            textPanel.gameObject.SetActive(false);
        }
        foreach (StatsApp statsAp in equipable.StatsApp)
        {
            StatsText[(int)statsAp.Stat-1].Init(statsAp.Value.ToString());
            StatsText[(int)statsAp.Stat-1].gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
    }

    private void SetButton(bool equipped)
    {
        if (equipped == true)
        {
            buttonText.text = "Снять";
            buttonImage.color = disequipColor;
        }
        else
        {
            buttonText.text = "Надeть";
            buttonImage.color = equipColor;
        }
    }

    public void ShoweEmpty()
    {
        gameObject.SetActive(false);
    }


}
