using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureHeroSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private int slotNumber;
    private Hero hero;
    private AdventurePanel adventurePanel;
    private Sprite defaultSprite;


    public void Init(Sprite sprite, int number, AdventurePanel adventurePanel)
    {
        slotNumber = number;
        icon.sprite = sprite;
        this.adventurePanel = adventurePanel;
        defaultSprite = sprite;
        gameObject.SetActive(true);
    }

    public void ChangeHero(Hero hero)
    {
        icon.sprite = hero.Icon;
        this.hero = hero;
        
    }

    public void ReturnHero()
    {
        if(hero!=null)
        {
            icon.sprite = defaultSprite;
            adventurePanel.ReturnHero(hero, slotNumber);
            hero = null;
        }
        
    }




}
