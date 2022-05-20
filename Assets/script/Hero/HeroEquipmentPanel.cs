using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEquipmentPanel : MonoBehaviour
{
    [SerializeField] private HeroPanel[] heroPanels;
    [SerializeField] private HeroesDetailedMenu heroesDetailedMenu;
    [SerializeField] private CommonHeir commonHeir;
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
        for(int i = 0;i< commonHeir.dataBase.hero.Count; i++)
        {
            heroPanels[i].Init(commonHeir.dataBase.hero[i]);
        }
        for (int i = commonHeir.dataBase.hero.Count; i < heroPanels.Length; i++)
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
        inventoryEquipmentPanel.ShowEquipable(targetHero.Clas, commonHeir.dataBase);
        
    }
    public void ShowDetailedEquipable(Equipable equipable)
    {
        targetEquipable = equipable;
        equipableDetailedPanel.ShowDetailedEquipable(targetEquipable);
    }
    public void ShowDetailedEquipableInHeroSlots(int equipmentSlot)
    {
        if (targetHero.Equipment[equipmentSlot] != null)
        {
            targetEquipable = targetHero.Equipment[equipmentSlot];
            equipableDetailedPanel.ShowDetailedEquipable(targetEquipable);
        }
        
    }
    public void Equip()
    {
        targetHero.Equip(targetEquipable, commonHeir.dataBase);
        ShoweDetailedHero(targetHero);
        ShowDetailedEquipable(targetEquipable);
    }


}
