using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AdventureHeroPanel : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text textHeroName;
    [SerializeField] private TMP_Text textHealth;
    [SerializeField] private TMP_Text textLevel;
    private AdventurePanel adventurePanel;
    private Hero hero;

    public void Init(Hero hero, AdventurePanel adventurePanel)
    {
        this.icon.sprite = hero.Icon;
        textHeroName.text = hero.Name;
        textLevel.text = hero.HeroLevel.Number.ToString();
        textHealth.text = hero.Stats[0].ToString() + "/"+ hero.Stats[1].ToString();
        this.adventurePanel = adventurePanel;
        this.hero = hero;
        gameObject.SetActive(true);
    }

    public void ChooseHero()
    {
        
        adventurePanel.ChooseHero(hero);
    }


}
