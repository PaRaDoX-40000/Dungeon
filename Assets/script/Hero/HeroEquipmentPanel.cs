using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEquipmentPanel : MonoBehaviour
{
    [SerializeField] private HeroPanel[] heroPanels;
    [SerializeField] private HeroesDetailedMenu heroesDetailedMenu;
    [SerializeField] private DataBase dataBase;
    [SerializeField] private InventoryEquipmentPanel inventoryEquipmentPanel;
    [SerializeField] private EquipableDetailedPanel equipableDetailedPanel;
    private Hero targetHero = null;
    private Equipable targetEquipable=null;

    private int maxHero=6; 
    

    //void Start()
    //{
    //    ShowHeroes();
    //    //ShowHeroesDetailedMenu(heros[1]);
    //}
    void OnEnable()
    {
        ShowHeroes();
        heroesDetailedMenu.ShoweEmpty();
        inventoryEquipmentPanel.ShoweEmpty();
        equipableDetailedPanel.ShoweEmpty();
    }

    void ShowHeroes()
    {
        for(int i = 0;i< dataBase.freeHero.Count; i++)
        {
            heroPanels[i].Init(dataBase.freeHero[i]);
        }
        for (int i = dataBase.freeHero.Count; i < heroPanels.Length; i++)
        {
            heroPanels[i].gameObject.SetActive(false);
        }       
    } 
    public void ShoweDetailedHero(Hero hero)
    {
        heroesDetailedMenu.ShoweDetailedHero(hero);
        targetHero = hero;
        ShoweEquipable();
        equipableDetailedPanel.ShoweEmpty();
    }
    public void ShoweEquipable()
    {
        inventoryEquipmentPanel.ShowEquipable(targetHero.Clas, dataBase);
        
    }
    public void ShowDetailedEquipable(Equipable equipable)
    {
        targetEquipable = equipable;
        equipableDetailedPanel.ShowDetailedEquipable(targetEquipable);
    }
    public void ShowDetailedEquipableInHeroSlots(int equipmentSlot)
    {
        if (targetHero.HeroEquipmentSlots[equipmentSlot].Equipped == true)
        {
            targetEquipable = targetHero.HeroEquipmentSlots[equipmentSlot].Equipable;
            equipableDetailedPanel.ShowDetailedEquipable(targetEquipable);
        }
        
    }
    public void Equip()
    {
        targetHero.Equip(targetEquipable, dataBase);
        ShoweDetailedHero(targetHero);
        ShowDetailedEquipable(targetEquipable);
    }


}
