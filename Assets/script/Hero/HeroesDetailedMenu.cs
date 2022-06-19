using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof (HeroesDetailedMenuUi))]
public class HeroesDetailedMenu : MonoBehaviour 
{
    [SerializeField] private TMP_Text[] stats;
    [SerializeField] private Image[] aitems;
    [SerializeField] private Image icon;
    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite defaultSprite;



    public void ShoweDetailedHero(Hero hero)
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (i == 0)
            {
                stats[i].text = hero.Stats[0] + "/" + hero.Stats[1];
                healthBar.fillAmount = (float)hero.Stats[0] / (float)hero.Stats[1];
            }
            else
                stats[i].text = hero.Stats[i + 1].ToString();
        }
        icon.sprite = hero.Icon;
        
        for (int j = 0; j < hero.HeroEquipmentSlots.Length; j++)
        {
            if (hero.HeroEquipmentSlots[j].Equipped == true)
            {                         
                aitems[j].sprite = hero.HeroEquipmentSlots[j].Equipable.Icon;
                aitems[j].gameObject.SetActive(true);                               
            }
            else
            {
                aitems[j].gameObject.SetActive(false);
            }
        }
        gameObject.SetActive(true);
       
    }
    public void ShoweEmpty()
    {
        foreach(TMP_Text stat in stats)
        {
            stat.text = " ";
        }
        foreach (Image aitem in aitems)
        {
            aitem.gameObject.SetActive(false);
        }
        icon.sprite = defaultSprite;
        healthBar.fillAmount = 1f;
    }


}
