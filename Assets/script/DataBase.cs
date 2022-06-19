using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenuAttribute(menuName = "DataBase")]
  public class DataBase: ScriptableObject
{
    public SaveDataHelper saveDataHelper;
    public List<Hero> hero = new List<Hero>();
    public List<Equipable> inventory = new List<Equipable>();
    
    public Dictionary<Loot, int> loots = new Dictionary<Loot, int>();
    public Dictionary<Consumable, int> consumables = new Dictionary<Consumable, int>();
    public int TimeNewHeroes;
    public List<Hero> ProposedHeroes = new List<Hero>();
    public int gold=10000;


    public List<ReportAdventure> reportAdventure= new List<ReportAdventure>();
 
    public List<Adventure> adventure = new List<Adventure>();

    //public List<Equipable> Inventory => inventory;

    private void Awake()
    {
        hero.Clear();
    }

    public void Save()
    {
        saveDataHelper.Save(loots, consumables);
    }
    public void Loading()
    {

        saveDataHelper.Loading(ref loots, ref consumables);
    }

    public void AddLoots(List<Loot> loots)
    {
       
        foreach (Loot loot in loots)
        {
            AddLoot(loot);
        }
    }
    public void AddLoot(Loot loot)
    {
        if (loots.ContainsKey(loot))
        {
            loots[loot]++;

        }
        else
        {
            loots.Add(loot, 1);
        }
    }
    public void TryRemoveLoots(List<Loot> loots)
    {
        foreach(Loot loot in loots)
        {
            TryRemoveLoot(loot);
        }
    }
    public void TryRemoveLoot(Loot loot, int number = 1)
    {
        if (loots.ContainsKey(loot))
        {
            if (loots[loot] - number >= 0)
            {
                loots[loot]-= number;
                if (loots[loot] == 0)
                {
                    loots.Remove(loot);
                }
            }
            
        }
    }



    public void AddConsumables(List<Consumable> consumables)
    {
        foreach (Consumable consumable in consumables)
        {
            AddConsumable(consumable);
        }
    }
    public void AddConsumable(Consumable consumable)
    {
        if (consumables.ContainsKey(consumable))
        {
            consumables[consumable]++;
        }
        else
        {
            consumables.Add(consumable, 1);
        }
    }
    public void TryRemoveConsumable(Consumable consumable,int number=1)
    {
        if (consumables.ContainsKey(consumable))
        {
            if(consumables[consumable]- number >= 0)
            {
                consumables[consumable]-= number;
                if (consumables[consumable] == 0)
                {
                    consumables.Remove(consumable);
                }
            }
            
        }
        
    }


    public void AddHeros(List<Hero> heroes)
    {
        hero.AddRange(heroes);
    }

    public void AddEquipable(Equipable equipable)
    {
        inventory.Add(equipable);
    }
    public void TruRemoveEquipable(Equipable equipable)
    {
        if (inventory.Contains(equipable))
        {
            inventory.Remove(equipable);
           
        }
        Debug.Log("no wat");
    }


    public bool TryСhangeGold(int value)
    {
        if(gold + value >= 0)
        {
            gold += value;
            return true;
        }
        else
        {
            return false;
        }
          
        

    }

}
