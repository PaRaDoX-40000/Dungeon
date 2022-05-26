using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurePanelUI : MonoBehaviour
{
  
    [SerializeField] private AdventureHeroPanel[] adventureHeroPanel;    
    [SerializeField] private AdventureConsumablesPanel[] adventureConsumablesPanel;    
    [SerializeField] private AdventureConsumableSlot[] adventureConsumableSlot;   
    [SerializeField] private AdventureHeroSlot[] adventureHeroSlot;    

    [SerializeField] private Sprite defaultHeroSlotSprite;

    [SerializeField] private AdventurePanel adventurePanel;

   

    

    public void ShowHeroes(List<Hero> heroes)
    {
        СlearChoiceMenu();
        for(int i=0;i< heroes.Count; i++)
        {
            adventureHeroPanel[i].Init(heroes[i], adventurePanel);
        }   
    }
    public void ShowConsumables(Dictionary<Consumable, int> consumables)
    {
        СlearChoiceMenu();

        Dictionary<Consumable, int>.KeyCollection consumablesKey = consumables.Keys;

        int i=0;
        foreach (Consumable consumable in consumablesKey)
        {
            adventureConsumablesPanel[i].Init(consumables[consumable].ToString(), consumable, adventurePanel);
            i++;
        }
    }

    private void СlearChoiceMenu()
    {
        foreach(AdventureHeroPanel heroPanel in adventureHeroPanel)
        {
            if (heroPanel.gameObject.activeSelf == false)
            {
                break;
            }
            heroPanel.gameObject.SetActive(false);
        }
        foreach (AdventureConsumablesPanel ConsumablesPanel in adventureConsumablesPanel)
        {
            if (ConsumablesPanel.gameObject.activeSelf == false)
            {
                break;
            }
            ConsumablesPanel.gameObject.SetActive(false);
        }

    }
    


    public void ChangeHero(Hero hero, int number)
    {
        adventureHeroSlot[number].ChangeHero(hero);
    }

    public void ShowConsumablesSlots(List<Consumable> consumables)
    {

        if (consumables.Count < adventureConsumableSlot.Length)
        {
            for (int i = 0; i < consumables.Count; i++)
            {
                adventureConsumableSlot[i].Init(consumables[i], adventurePanel);
            }
            for (int i = consumables.Count; i < adventureConsumableSlot.Length; i++)
            {
                adventureConsumableSlot[i].gameObject.SetActive(false);
            }

        }
        else
        {
            Debug.LogError("количкство предметов привысело количество ячеек");
        }

    }

    public void СreateHeroSlot(int numberSlots)
    {
        for(int i=0;i< numberSlots; i++)
        {
            adventureHeroSlot[i].Init(defaultHeroSlotSprite, i, adventurePanel);
        }
        for(int i= numberSlots; i < adventureHeroSlot.Length; i++)
        {
            adventureHeroSlot[i].gameObject.SetActive(false);
        }
       
    }






}
