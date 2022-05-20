using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftEquipablePanelUI : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Image iconImage;
    [SerializeField] private Button[] buttonsStats;
    [SerializeField] private Button buttonCraft;
    [SerializeField] private Text golgText;

    public void Init(Sprite sprite,StatsApp.Stats[] activeIndex,int gold)
    {
        Clear();
        iconImage.sprite = sprite;        
        foreach (int i in activeIndex)
        {
            buttonsStats[i - 1].gameObject.SetActive(true);
        }        
        golgText.text = gold.ToString();
    }
    public void Clear()
    {
        foreach (Button button in buttonsStats)
        {
            button.gameObject.SetActive(false);
        }
        buttonCraft.interactable = false;
        iconImage.sprite = defaultSprite;
        golgText.text = "0";
    }

    public void changeGold(int gold)
    {
        golgText.text = gold.ToString();
    }

    public void SetActiveButtonCraft(bool Active)
    {
        buttonCraft.interactable = Active;
    }



}
