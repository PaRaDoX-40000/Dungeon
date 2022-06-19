using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroPanel : MonoBehaviour //RepotHeroPanel
{

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text textHeroName;
    [SerializeField] private TMP_Text textHealth;
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private HeroEquipmentPanel HeroEquipmentPanel;
    protected Hero hero;

    public void Init(Hero hero)
    {
        icon.sprite = hero.Icon;
        textHeroName.text = hero.Name;
        textLevel.text = hero.HeroLevel.Number.ToString();
        textHealth.text = hero.Stats[0].ToString() + "/" + hero.Stats[1].ToString();        
        this.hero = hero;
        gameObject.SetActive(true);
    }

   public virtual void ShoweDetailedHero()
    {
        HeroEquipmentPanel.ShoweDetailedHero(hero);
    }

}
